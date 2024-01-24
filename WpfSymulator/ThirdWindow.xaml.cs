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
using static System.Reflection.Metadata.BlobBuilder;

namespace WpfSymulator
{
    /// <summary>
    /// Interaction logic for ThirdWindow.xaml
    /// </summary>
    public partial class ThirdWindow : Window
    {
        /// <summary>
        /// Fields responsible for a new bracket, list of clubs, users club of choice and groups A to D
        /// </summary>
        public static ChampionshipBracket championshipBracket = new ChampionshipBracket();
        public static List<Club> wszystkieKluby = new List<Club>();
        public static Club userPick = new Club();
        public List<Club> grupaA = new List<Club>();
        public List<Club> grupaB = new List<Club>();
        public List<Club> grupaC = new List<Club>();
        public List<Club> grupaD = new List<Club>();
        /// <summary>
        /// Initialises ThirdWindow, creates a randomised bracket and shows pairs of clubs that play against each other
        /// </summary>
        public ThirdWindow()
        {
            InitializeComponent();
            grupaA.Clear();
            grupaB.Clear();
            grupaC.Clear();
            grupaD.Clear();
            championshipBracket = new ChampionshipBracket();
            wszystkieKluby = MainWindow.wszystkieKluby;
            userPick = SecondWindow.userPick;
            championshipBracket.AddToGroupA(userPick);
            Random r = new Random();
            while (wszystkieKluby.Count > 0)
            {
                if (wszystkieKluby.Count == 7)
                {
                    int los = r.Next(0, wszystkieKluby.Count);
                    championshipBracket.AddToGroupA(wszystkieKluby[los]);
                    wszystkieKluby.Remove(wszystkieKluby[los]);
                }
                else if (wszystkieKluby.Count >= 5 && wszystkieKluby.Count <= 6)
                {
                    int los = r.Next(0, wszystkieKluby.Count);
                    championshipBracket.AddToGroupB(wszystkieKluby[los]);
                    wszystkieKluby.Remove(wszystkieKluby[los]);
                }
                else if (wszystkieKluby.Count >= 3 && wszystkieKluby.Count <= 4)
                {
                    int los = r.Next(0, wszystkieKluby.Count);
                    championshipBracket.AddToGroupC(wszystkieKluby[los]);
                    wszystkieKluby.Remove(wszystkieKluby[los]);
                }
                else
                {
                    int los = r.Next(0, wszystkieKluby.Count);
                    championshipBracket.AddToGroupD(wszystkieKluby[los]);
                    wszystkieKluby.Remove(wszystkieKluby[los]);
                }
            }
            firstTeam.Text = championshipBracket.grupaA[0].ToString() + "VS" + "\n" + championshipBracket.grupaA[1].ToString();
            firstTeam.TextAlignment = TextAlignment.Center;
            thirdTeam.Text = championshipBracket.grupaB[0].ToString() + "VS" + "\n" + championshipBracket.grupaB[1].ToString();
            thirdTeam.TextAlignment = TextAlignment.Center;
            fifthTeam.Text = championshipBracket.grupaC[0].ToString() + "VS" + "\n" + championshipBracket.grupaC[1].ToString();
            fifthTeam.TextAlignment = TextAlignment.Center;
            seventhTeam.Text = championshipBracket.grupaD[0].ToString() + "VS" + "\n" + championshipBracket.grupaD[1].ToString();
            seventhTeam.TextAlignment = TextAlignment.Center;
        }
        /// <summary>
        /// Handles GameButton object, starts all of the matches, determines scores, winners and losers. Depending on the players team score LoseWindow or FourthWindow opens
        /// </summary>
        /// <param name="sender">GameButton button in ThirdWindow</param>
        /// <param name="e">Button being clicked</param>
        private async void GameButton_Click(object sender, RoutedEventArgs e)
        {
            GameButton.Visibility = Visibility.Collapsed;
            Game g1 = new Game();
            g1.playingMatch(championshipBracket.grupaA);
            Game g2 = new Game();
            g2.playingMatch(championshipBracket.grupaB);
            Game g3 = new Game();
            g3.playingMatch(championshipBracket.grupaC);
            Game g4 = new Game();
            g4.playingMatch(championshipBracket.grupaD);
            Results r1 = new Results();
            Results r2 = new Results();
            Results r3 = new Results();
            Results r4 = new Results();
            r1.LosowanieWynikow();
            r2.LosowanieWynikow();
            r3.LosowanieWynikow();
            r4.LosowanieWynikow();
            firstTeam.Text = g1.playingMatch(championshipBracket.grupaA).ToString() + r1.wygrany.ToString() + "\n" + g1.loser.ToString() + r1.przegrany.ToString();
            thirdTeam.Text = g2.playingMatch(championshipBracket.grupaB).ToString() + r2.wygrany.ToString() + "\n" + g2.loser.ToString() + r2.przegrany.ToString();
            fifthTeam.Text = g3.playingMatch(championshipBracket.grupaC).ToString() + r3.wygrany.ToString() + "\n" + g3.loser.ToString() + r3.przegrany.ToString();
            seventhTeam.Text = g4.playingMatch(championshipBracket.grupaD).ToString() + r4.wygrany.ToString() + "\n" + g4.loser.ToString() + r4.przegrany.ToString();
            TekstSpr.Text = "QUARTERFINALS RESULTS";
            await Task.Delay(3000);
            firstTeam.Text = g1.winner.Nazwa.ToString();
            firstTeam.FontWeight = FontWeights.Bold;
            firstTeam.FontSize = 20;
            firstTeam.TextWrapping = TextWrapping.Wrap;
            thirdTeam.Text = g2.winner.Nazwa.ToString();
            thirdTeam.FontWeight = FontWeights.Bold;
            thirdTeam.FontSize = 20;
            thirdTeam.TextWrapping = TextWrapping.Wrap;
            fifthTeam.Text = g3.winner.Nazwa.ToString();
            fifthTeam.FontWeight = FontWeights.Bold;
            fifthTeam.FontSize = 20;
            fifthTeam.TextWrapping = TextWrapping.Wrap;
            seventhTeam.Text = g4.winner.Nazwa.ToString();
            seventhTeam.FontWeight = FontWeights.Bold;
            seventhTeam.FontSize = 20;
            seventhTeam.TextWrapping = TextWrapping.Wrap;
            TekstSpr.Text = "QUARTERFINALS WINNERS";
            wszystkieKluby.Remove(userPick);
            wszystkieKluby.Add(g1.winner); 
            wszystkieKluby.Add(g2.winner);
            wszystkieKluby.Add(g3.winner);
            wszystkieKluby.Add(g4.winner);
            grupaA.Clear();
            grupaB.Clear();
            grupaC.Clear();
            grupaD.Clear();
            
            await Task.Delay(3000);
            if (!wszystkieKluby.Contains(userPick))
            {
                LoseWindow ls = new LoseWindow();
                ls.Show();
                this.Close();
            }
            else 
            {
                FourthWindow fw = new FourthWindow();
                fw.Show();
                this.Close();
            }
            
        }
    }
}
