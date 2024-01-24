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
    /// Interaction logic for LoseWindow.xaml
    /// </summary>
    public partial class LoseWindow : Window
    {
        /// <summary>
        /// Fields responsible for a new bracket, list of clubs, users club of choice and a delegate to SavePlayerProfile method of MainWindow.xaml.cs
        /// </summary>
        public static ChampionshipBracket championshipBracket = new ChampionshipBracket();
        public static Club userPick;
        public static List<Club> wszystkieKluby;
        private SavePlayerProfileDelegate savePlayerProfileDelegate;

        /// <summary>
        /// Initialises LoseWindow and displays users club of choice as eliminated form the tournament bracket
        /// </summary>
        public LoseWindow()
        {
            InitializeComponent();
            userPick = SecondWindow.userPick;
            TekstSpr.Text = TekstSpr.Text + "\n" + userPick.Nazwa.ToString() + " GETS ELIMINATED!";
            string source = userPick.imageSource.ToString();
            finalImage.Source = new BitmapImage(new Uri(source, UriKind.RelativeOrAbsolute));
            lostBox.Text = userPick.Nazwa.ToString();
            lostBox.FontSize = 20;
            lostBox.Foreground = Brushes.Black;
            savePlayerProfileDelegate = MainWindow.SavePlayerProfile;
        }
        /// <summary>
        /// Handles PlayAgainButton object, if player profile isnt default saves the gamestate, clears bracket, users pick and the list of clubs. Opens MainWindow again
        /// </summary>
        /// <param name="sender">PlayAgainButton button in LoseWindow</param>
        /// <param name="e">The button being clicked</param>
        private void PlayAgainButton_Click(object sender, RoutedEventArgs e)
        {
            bool playerState = (bool)Application.Current.Properties["playerState"];
            if (!(playerState))
            {
                try
                {
                    DBPlayerProfile currentPlayer = (DBPlayerProfile)Application.Current.Properties["currentPlayer"];
                    currentPlayer.numberOfLosses++;
                    savePlayerProfileDelegate(currentPlayer, $"{currentPlayer.Name}.xml");
                }
                catch (XmlSerializationException ex) { MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            else
            {
                DefaultPlayerProfile currentPlayer = (DefaultPlayerProfile)Application.Current.Properties["currentPlayer"];
                currentPlayer.numberOfLosses++;
            }
            PlayAgainButton.IsEnabled = false;
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
        /// <param name="sender">ExitButton button in LoseWindow</param>
        /// <param name="e">The button being clicked</param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            bool playerState = (bool)Application.Current.Properties["playerState"];
            if (!(playerState))
            {
                try
                {
                    DBPlayerProfile currentPlayer = (DBPlayerProfile)Application.Current.Properties["currentPlayer"];
                    currentPlayer.numberOfLosses++;
                    savePlayerProfileDelegate(currentPlayer, $"{currentPlayer.Name}.xml");
                }
                catch (XmlSerializationException ex) { MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
            }
            else
            {
                DefaultPlayerProfile currentPlayer = (DefaultPlayerProfile)Application.Current.Properties["currentPlayer"];
                currentPlayer.numberOfLosses++;
            }
            ExitButton.IsEnabled = false;
            Application.Current.Shutdown();
        }
    }
}
