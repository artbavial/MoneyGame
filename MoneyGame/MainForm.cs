using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using MoneyGame.Logic;
using MoneyGame.Stock;

namespace MoneyGame
{
    public partial class MainForm : Form
    {
        private readonly Game game;
        private DateTime lastDate;
        
        public MainForm(Game game)
        {
            InitializeComponent();

            var rateMap = Mappers.Xy<Rate>()
                .X(r => (double)r.Date.Ticks)
                .Y(r => (double)r.Value);
            Charting.For<Rate>(rateMap);

            StackChart.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Золото",
                        Values = new ChartValues<Rate>(),
                        PointGeometrySize = 10
                    }
                };

            StackChart.AxisX.Add(new Axis
            {
                LabelFormatter = (ticks) => new DateTime((long)ticks).ToString("d")
            });

            StackChart.AxisY.Add(new Axis
            {
                LabelFormatter = (x) => $"${x:0.00}"
            });

            this.game = game;
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            Update(game.State);
        }

        private void Update(GameState state)
        {
            var series = StackChart.Series.Single();
            for (int i = 0; i < state.GoldHistory.Count; i++)
            {
                if (series.Values.Count > i)
                {
                    series.Values[i] = state.GoldHistory[i];
                } else
                {
                    series.Values.Add(state.GoldHistory[i]);
                }
            }

            foreach (var newEvent in state.Events.Where(e => e.Date > lastDate))
            {
                eventsBox.DeselectAll();
                eventsBox.SelectionFont = new Font(eventsBox.SelectionFont, FontStyle.Bold);
                eventsBox.AppendText(newEvent.Date.ToString("d") + ": ");
                eventsBox.SelectionFont = new Font(eventsBox.SelectionFont, FontStyle.Regular);
                eventsBox.AppendText(newEvent.Message + Environment.NewLine);
            }

            if (eventsBox.Lines.Count() > 25)
            {
                eventsBox.Select(0, eventsBox.GetFirstCharIndexFromLine(eventsBox.Lines.Count() - 25));
                eventsBox.SelectedText = "";
                eventsBox.Select(eventsBox.TextLength, 0);
            }

            eventsBox.ScrollToCaret();

            lastDate = state.Date;
        }

        private void GameTimer(object sender, EventArgs e)
        {
            game.Next();
            Update(game.State);
        }
    }
}
