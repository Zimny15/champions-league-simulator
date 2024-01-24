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
    /// Interaction logic for FifthWindow.xaml
    /// </summary>
    public partial class FifthWindow : Window
    {
        /// <summary>
        /// Fields responsible for a new bracket, list of clubs, users club of choice, group A and a delegate to SavePlayerProfile method of MainWindow.xaml.cs
        /// </summary>
        public static ChampionshipBracket championshipBracket = new ChampionshipBracket();
        public static List<Club> wszystkieKluby;
        public static Club userPick;
        public List<Club> grupaA = new List<Club>();
        private SavePlayerProfileDelegate savePlayerProfileDelegate;
        /// <summary>
        /// Initialises the FifthWindow, group A, list of clubs and adjusts the visibility of UI components
        /// </summary>
        public FifthWindow()
        {
            InitializeComponent();
            winningMusic.Pause();
            PlayAgainButton.Visibility = Visibility.Collapsed;
            ExitButton.Visibility = Visibility.Collapsed;
            wszystkieKluby = FourthWindow.wszystkieKluby;
            userPick = SecondWindow.userPick;
            grupaA.Clear();
            championshipBracket = new ChampionshipBracket();
            championshipBracket.AddToGroupA(wszystkieKluby[0]);
            championshipBracket.AddToGroupA(wszystkieKluby[1]);
            finalGame.Text = championshipBracket.grupaA[0].ToString() + "VS" + "\n" + championshipBracket.grupaA[1].ToString();
            finalGame.TextAlignment = TextAlignment.Center;
            finalGame.FontWeight = FontWeights.Bold;
            savePlayerProfileDelegate = MainWindow.SavePlayerProfile;

        }

        /// <summary>
        /// Handles GameButton object, starts the final match, determines score, winner and loser and adjusts visibility of UI elements. If the players team loses LoseWindow is opened
        /// </summary>
        /// <param name="sender">GameButton button in FifthWindow</param>
        /// <param name="e">Button being clicked</param>
        private async void GameButton_Click(object sender, RoutedEventArgs e)
        {
            GameButton.Visibility = Visibility.Collapsed;
            Game g1 = new Game();
            g1.playingMatch(championshipBracket.grupaA);
            Results r1 = new Results();
            r1.LosowanieWynikow();
            finalGame.Text = g1.winner.ToString() + r1.wygrany.ToString() + "\n" + g1.loser.ToString() + r1.przegrany.ToString();
            finalGame.FontWeight = FontWeights.Bold;
            finalGame.TextAlignment = TextAlignment.Center;
            TekstSpr.Text = "FINAL SCORE";
            grupaA.Clear();
            await Task.Delay(3000);
            if (g1.winner != userPick)
            {
                LoseWindow ls = new LoseWindow();
                ls.Show();
                this.Close();
            }
            winningMusic.Play();
            finaltitle.Margin = new Thickness(0, 0, 0, 0);
            finaltitle.Text = string.Empty;
            finalGame.Text = g1.winner.Nazwa.ToString();
            TekstSpr.Text = "YOU WON!\nCONGRATULATIONS!";
            TekstSpr.FontWeight = FontWeights.Bold;
            TekstSpr.Margin = new Thickness(30);
            finalGame.FontWeight = FontWeights.Bold;
            finalGame.TextAlignment = TextAlignment.Center;
            finalGame.FontSize = 22;
            finalGame.Foreground = Brushes.Black;
            finalImage.Margin = new Thickness(0,100,0,0);
            finalImage.Width = 180;
            finalImage.Height = 180;
            string source = g1.winner.imageSource.ToString();
            finalImage.Source = new BitmapImage(new Uri(source, UriKind.RelativeOrAbsolute));
            PlayAgainButton.Visibility = Visibility.Visible;
            ExitButton.Visibility = Visibility.Visible;

        }
        /// <summary>
        /// Handles PlayAgainButton object, if player profile isnt default saves the gamestate, clears bracket, users pick and the list of clubs. Opens MainWindow again
        /// </summary>
        /// <param name="sender">PlayAgainButton button in FifthWindow</param>
        /// <param name="e">The button being clicked</param>
        private void PlayAgainButton_Click(object sender, RoutedEventArgs e)
        {
            bool playerState = (bool)Application.Current.Properties["playerState"];
            PlayAgainButton.IsEnabled = false;
            ExitButton.IsEnabled = false;
            if (!(playerState))
            {
                try
                {
                    DBPlayerProfile currentPlayer = (DBPlayerProfile)Application.Current.Properties["currentPlayer"];
                    currentPlayer.numberOfWins++;
                    savePlayerProfileDelegate(currentPlayer, $"{currentPlayer.Name}.xml");
                }
                catch (XmlSerializationException ex) { MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            else
            {
                DefaultPlayerProfile currentPlayer = (DefaultPlayerProfile)Application.Current.Properties["currentPlayer"];
                currentPlayer.numberOfWins++;
            }
            userPick = null;
            wszystkieKluby = null;
            championshipBracket = null;
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
        /// <summary>
        /// Handles ExitButton object, if player profile isnt default saves the gamestate and shuts down the application
        /// </summary>
        /// <param name="sender">ExitButton button in FifthWindow</param>
        /// <param name="e">The button being clicked</param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            bool playerState = (bool)Application.Current.Properties["playerState"];
            if (!(playerState))
            {
                try
                {
                    DBPlayerProfile currentPlayer = (DBPlayerProfile)Application.Current.Properties["currentPlayer"];
                    currentPlayer.numberOfWins++;
                    savePlayerProfileDelegate(currentPlayer, $"{currentPlayer.Name}.xml");
                }
                catch (XmlSerializationException ex) { MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            else 
            {
                DefaultPlayerProfile currentPlayer = (DefaultPlayerProfile)Application.Current.Properties["currentPlayer"];
                currentPlayer.numberOfWins++;
            }
            Application.Current.Shutdown();
            
            
        }
    }
}
