using MoneyGame.Logic;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MoneyGame
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();

            Init();
            UpdateStartState();

            NameTextBox.TextChanged += (s, e) => UpdateStartState();
            CompanyTextBox.TextChanged += (s, e) => UpdateStartState();
        }

        [Conditional("DEBUG")]
        private void Init()
        {
            NameTextBox.Text = "Alex";
            CompanyTextBox.Text = "ОАО Разорищенск";
        }

        private void UpdateStartState()
        {
            buttonStart.Enabled = !NameTextBox.IsEmpty() && !CompanyTextBox.IsEmpty();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            var  player = new Player
            {
                Name = NameTextBox.Text,
                Company = CompanyTextBox.Text
            };

            var game = new Game(player, DateTime.Today);
            for (int i = 0; i < Game.MaxRatesInHistory; i++)
            {
                game.Next();
            }

            var main = new MainForm(game);
            Hide();
            main.Show();
            main.FormClosed += (s, _) => this.Close();
        }
    }
}
