using Symulator_CL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfSymulator
{
    /// <summary>
    /// Interaction logic for FourthWindow.xaml
    /// </summary>
    public partial class FourthWindow : Window
    {
        /// <summary>
        /// Fields responsible for a new bracket, list of clubs, users club of choice and groups A and B
        /// </summary>
        public static ChampionshipBracket championshipBracket = new ChampionshipBracket();
        public static List<Club> wszystkieKluby;
        public static Club userPick;
        public List<Club> grupaA = new List<Club>();
        public List<Club> grupaB = new List<Club>();
   
        /// <summary>
        /// Initialises the FourthWindow, a new bracket, groups A and B and showcases pairs of clubs that play against each other
        /// </summary>
        public FourthWindow()
        {
            InitializeComponent();
            wszystkieKluby = ThirdWindow.wszystkieKluby;
            userPick = SecondWindow.userPick;
            grupaA.Clear();
            grupaB.Clear();
            championshipBracket = new ChampionshipBracket();
            Random r = new Random();
            while (wszystkieKluby.Count > 0)
            {
                if (wszystkieKluby.Count >=3)
                {
                    int los = r.Next(0, wszystkieKluby.Count);
                    championshipBracket.AddToGroupA(wszystkieKluby[los]);
                    wszystkieKluby.Remove(wszystkieKluby[los]);
                }
                else
                {
                    int los = r.Next(0, wszystkieKluby.Count);
                    championshipBracket.AddToGroupB(wszystkieKluby[los]);
                    wszystkieKluby.Remove(wszystkieKluby[los]);
                }
            }
            firstTeams.Text = championshipBracket.grupaA[0].ToString() + "VS" + "\n" + championshipBracket.grupaA[1].ToString();
            firstTeams.TextAlignment = TextAlignment.Center;
            secondTeams.Text = championshipBracket.grupaB[0].ToString() + "VS" + "\n" + championshipBracket.grupaB[1].ToString();
            secondTeams.TextAlignment = TextAlignment.Center;
        }
        /// <summary>
        /// Handles GameButton object, starts all of the matches, determines scores, winners and losers. Depending on the players team score LoseWindow or FifthWindow opens
        /// </summary>
        /// <param name="sender">GameButton button in FourthWindow</param>
        /// <param name="e">Button being clicked</param>
        private async void GameButton_Click(object sender, RoutedEventArgs e)
        {
            GameButton.Visibility = Visibility.Collapsed;
            Game g1 = new Game();
            g1.playingMatch(championshipBracket.grupaA);
            Game g2 = new Game();
            g2.playingMatch(championshipBracket.grupaB);
            Results r1 = new Results();
            Results r2 = new Results();
            r1.LosowanieWynikow();
            r2.LosowanieWynikow();
            firstTeams.Text = g1.playingMatch(championshipBracket.grupaA).ToString() + r1.wygrany.ToString() + "\n" + g1.loser.ToString() + r1.przegrany.ToString();
            secondTeams.Text = g2.playingMatch(championshipBracket.grupaB).ToString() + r2.wygrany.ToString() + "\n" + g2.loser.ToString() + r2.przegrany.ToString();
            TekstSpr.Text = "SEMIFINALS RESULTS";
            await Task.Delay(3000);
            firstTeams.Text = g1.winner.Nazwa.ToString();
            firstTeams.FontWeight = FontWeights.Bold;
            firstTeams.FontWeight = FontWeights.Bold;
            firstTeams.FontSize = 20;
            secondTeams.Text = g2.winner.Nazwa.ToString();
            secondTeams.FontWeight = FontWeights.Bold;
            secondTeams.FontSize = 20;
            secondTeams.FontWeight = FontWeights.Bold;
            TekstSpr.Text = "SEMIFINALS WINNERS";
            wszystkieKluby.Add(g1.winner);
            wszystkieKluby.Add(g2.winner);
            grupaA.Clear();
            grupaB.Clear();
            await Task.Delay(3000);
            if (!wszystkieKluby.Contains(userPick))
            {
                LoseWindow ls = new LoseWindow();
                ls.Show();
                this.Close();
            }
            else
            {
                FifthWindow fw = new FifthWindow();
                fw.Show();
                this.Close();
            } 
        }
    }
}
