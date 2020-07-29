using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveRacersManager
{
    public partial class Form1 : Form
    {
        private static string url = @"https://sr2020.liveracers.com/odata-v4/SessionResults/?$count=true&%24skip=0&%24top=100&%24orderby=StartDate%20desc";

        private static string standingsUrl = @"https://sr2020.liveracers.com/api/SessionDrivers?sessionId={0}";

        public IOrderedEnumerable<Standing> Standings { get; set; }

        public Form1()
        {
            InitializeComponent();
            FillControls();
            this.numericUpDown1.Value = 60;

        }

        private async void FillControls()
        {
            listaDeResultados.DataSource = (await CallResults()).value;
        }

        public async Task<ResultList> CallResults()
        {
            this.Enabled = false;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    this.Enabled = true;
                    return JsonConvert.DeserializeObject<ResultList>(apiResponse);
                }
            }
        }

        public async Task<IOrderedEnumerable<Standing>> CallStandings(Guid id)
        {
            var url = String.Format(standingsUrl, id);

            this.Enabled = false;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    var list = JsonConvert.DeserializeObject<List<Standing>>(resp);
                    this.Enabled = true;
                    return list.OrderBy(s => s.EndPosition);
                }
            }
        }

        private async void listBox1_SelectedValueChangedAsync(object sender, EventArgs e)
        {
            var box = sender as ListBox;
            var item = box.SelectedItem as Result;

            Standings = await CallStandings(item.Id);

            posicionesTextBox.Text = Standings.ExtendedToString();
            ReordenarGrilla();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            posicionesTextBox.SetBounds(0, 0, 0, 0, BoundsSpecified.None);
        }

        private void ReordenarGrilla()
        {
            if (Standings != null)
            {
                var porcentaje = numericUpDown1.Value;

                var cantidadDePilotos = Standings.Count();
                var posicionesARotar = (int)Math.Round(cantidadDePilotos * porcentaje / 100);
                var posicionesFinales = Standings.Take(posicionesARotar).OrderByDescending(a => a.EndPosition)
                    .Concat(Standings.Skip(posicionesARotar).OrderBy(a => a.EndPosition));
                var pos = 1;
                foreach (var item in posicionesFinales)
                {
                    item.NewPosition = pos++;
                }
                richTextBox1.Text = posicionesFinales.ReorderToString();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ReordenarGrilla();
        }
    }
}
