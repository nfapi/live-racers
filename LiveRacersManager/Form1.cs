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
            var todosLosResultados = (await CallResults()).value;
            listaDeResultados.DataSource = todosLosResultados;

            ArmarReporteDeVueltas(todosLosResultados);
            //var total = 435;
            //var clean = 222;
            //var piloto = "N FAPITALLE";
            //reporteTxt.Text = string.Format("{0,5} = {1,5} = {2}", total, clean, piloto);

        }

        private async void ArmarReporteDeVueltas(List<Result> todosLosResultados)
        {
            var sb = new StringBuilder();
            reporteTxt.Text = string.Empty;
            progressBar1.Maximum = todosLosResultados.Count();
            progressBar1.Value = 0;
            foreach (var grupo in todosLosResultados.GroupBy(r => r.Track))
            {
                sb.AppendLine(grupo.Key);
                Dictionary<string, ShortStanding> dic = new Dictionary<string, ShortStanding>();
                foreach (var resultado in grupo)
                {
                    var url = String.Format(standingsUrl, resultado.Id);
                    using (var client = new HttpClient())
                    {
                        using (var response = await client.GetAsync(url))
                        {
                            string resp = await response.Content.ReadAsStringAsync();
                            var list = JsonConvert.DeserializeObject<List<Standing>>(resp);
                            foreach (var item in list)
                            {
                                if (!dic.ContainsKey(item.Name))
                                    dic.Add(item.Name, item);
                                else
                                {
                                    dic[item.Name].TotalLaps += item.TotalLaps;
                                    dic[item.Name].CleanLaps += item.CleanLaps;
                                    dic[item.Name].Incidents += item.Incidents;
                                }
                            }
                        }
                    }
                    progressBar1.Value += progressBar1.Step;
                }
                foreach (var item in dic.OrderByDescending(k => k.Value.TotalLaps))
                {
                    sb.AppendLine(string.Format("T{0,5} |C{1,5} |I{2,5} |{3}", item.Value.TotalLaps, item.Value.CleanLaps, item.Value.Incidents, item.Value.Name));
                }
            }
            reporteTxt.Text = sb.ToString();

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FillControls();
        }
    }
}
