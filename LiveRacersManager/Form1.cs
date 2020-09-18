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
            //var lap = 96.4657;
            //var clean = 222;
            //var piloto = "N FAPITALLE";
            //var l = TimeSpan.FromSeconds(lap).ToString(@"mm\:ss\.fff");
            //reporteTxt.Text = string.Format("{0} = {1,5} = {2}", l, clean, piloto);

        }

        private async void ArmarReporteDeVueltas(List<Result> todosLosResultados)
        {
            reporteTxt.Text = string.Empty;
            progressBar1.Maximum = todosLosResultados.Count();
            progressBar1.Value = 0;
            foreach (var grupo in todosLosResultados.GroupBy(r => r.Track))
            {
                var sb = new StringBuilder();
                sb.AppendLine(grupo.Key);
                sb.AppendLine(" Mejor     | Laps | Piloto");
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
									dic[item.Name].BestLap = item.BestLap > 0 ? Math.Min(item.BestLap, dic[item.Name].BestLap) : dic[item.Name].BestLap;
                                }
                            }
                        }
                    }
                    progressBar1.Value += progressBar1.Step;
                }
                foreach (var item in dic.OrderByDescending(k => k.Value.CleanLaps))
                {
                    var l = TimeSpan.FromSeconds(item.Value.BestLap).ToString(@"mm\:ss\.fff");
                    sb.AppendLine(string.Format("{0,10} |{1,5} | {2}", l, item.Value.CleanLaps, item.Value.Name));
                }
                reporteTxt.Text += sb.ToString();
            }
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
