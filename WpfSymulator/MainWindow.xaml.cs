using Symulator_CL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace WpfSymulator
{

    /// <summary>
    /// Delegate to the SavePlayerProfile method
    /// </summary>
    /// <param name="player">Player profile to be saved</param>
    /// <param name="xmlFile">Name of a save file</param>
    public delegate void SavePlayerProfileDelegate(DBPlayerProfile player, string xmlFile);

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Fields representing state of music playback, excel reader class, list of clubs and new name created by the user
        /// </summary>
        private bool isMusicPaused = false;
        public static ExcelReaderInterop excelReader = new ExcelReaderInterop();
        public static List<Club> wszystkieKluby = new List<Club>();
        private string newName;

        /// <summary>
        /// Refreshes the listbox contents based on the contents of a database
        /// </summary>
        public void refreshListBox()
        {
            List<String> dbPlayerProfiles = DBConnection.GetPlayerList();
            playerProfileChoice.ItemsSource = dbPlayerProfiles;
        }
        /// <summary>
        /// Loads a player profile from an xml save file
        /// </summary>
        /// <param name="xmlFile">Name of the save file</param>
        /// <returns>A player profile deserialized from a save file</returns>
        /// <exception cref="XmlDeserializationException">Thrown when deserialization is not successful</exception>
        public static DBPlayerProfile LoadPlayerProfile(string xmlFile)
        {
            DBPlayerProfile playerProfile;

            try
            {
                using (FileStream fs = new FileStream(xmlFile, FileMode.Open))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(DBPlayerProfile));
                    return (DBPlayerProfile)xs.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                throw new XmlDeserializationException("Profile loading error! Are you missing a save file?",ex);
            }
        }

        /// <summary>
        /// Saves a player profile to an xml file
        /// </summary>
        /// <param name="player">Player profile to be saved</param>
        /// <param name="xmlFile">Name of a save file</param>
        /// <exception cref="XmlSerializationException">Thrown when serialization is not successful</exception>
        public static void SavePlayerProfile(DBPlayerProfile playerProfile, string xmlFile)
        {
            try
            {
                using (StreamWriter sw = new(xmlFile))
                {
                    XmlSerializer xs = new(typeof(DBPlayerProfile));
                    xs.Serialize(sw, playerProfile);
                }
            }
            catch(Exception ex) { throw new XmlSerializationException("Saving error!", ex); }
        }
        /// <summary>
        /// Initialisation of the MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            startButton.Visibility = Visibility.Collapsed;
            showScore.Visibility = Visibility.Collapsed;

            //If a player profile is passed from LoseWindow or FifthWindow adjusts the visibility of UI elements
            if (Application.Current.Properties["currentPlayer"] != null)
            {
                playerProfileChoice.Visibility = Visibility.Collapsed;
                createButton.Visibility = Visibility.Collapsed;
                newPlayerProfile.Visibility = Visibility.Collapsed;
                showScore.Visibility = Visibility.Visible;
                htpExpander.Visibility = Visibility.Collapsed;
                defaultPlayerStart.Visibility = Visibility.Collapsed;
                startButton.Visibility = Visibility.Visible;
            }

            // Play music and read Excel player data
            introMusic.Play();
            wszystkieKluby.Clear();
            wszystkieKluby = excelReader.ReadExcelPlayers();

            //Assign crests to each of the clubs
            foreach (var item in wszystkieKluby)
            {
                if (item.Nazwa == "Real Madrit")
                {
                    item.DodajSourceImage(@"Images\real_logo.png");
                }
                if (item.Nazwa == "FC Barcelona")
                {
                    item.DodajSourceImage(@"Images\barcelona_logo.png");
                }
                if (item.Nazwa == "Manchester City")
                {
                    item.DodajSourceImage(@"Images\city_logo.png");
                }
                if (item.Nazwa == "Manchester United")
                {
                    item.DodajSourceImage(@"Images\united_logo.png");
                }
                if (item.Nazwa == "PSG")
                {
                    item.DodajSourceImage(@"Images\psg_logo.png");
                }
                if (item.Nazwa == "Liverpool")
                {
                    item.DodajSourceImage(@"Images\liverpool_logo.png");
                }
                if (item.Nazwa == "FC Bayern")
                {
                    item.DodajSourceImage(@"Images\bayern_logo.png");
                }
                if (item.Nazwa == "Wisla Krakow")
                {
                    item.DodajSourceImage(@"Images\wisla_logo.png");
                }
            }
            //Gets a list of player profiles from a database and sets it as a source of listbox items
            List<String> dbPlayerProfiles = DBConnection.GetPlayerList();
            playerProfileChoice.ItemsSource = dbPlayerProfiles;

        }
        /// <summary>
        /// Handles the listbox UI element and the users clicks
        /// </summary>
        /// <param name="sender">Listbox in MainWIndow</param>
        /// <param name="e">User clicking at one of the items in the listbox' selection</param>
        private void PrintText(object sender, SelectionChangedEventArgs e) 
        {
            bool playerState = false;
            Application.Current.Properties["playerState"] = playerState;
            defaultPlayerStart.Visibility = Visibility.Collapsed;
            startButton.Visibility = Visibility.Visible;
            ListBox profile = (ListBox)sender;
            playerProfileChoice.IsEnabled = false;
            string playerName = (string)profile.SelectedItem;
            try 
            {
                
                DBPlayerProfile currentPlayer = LoadPlayerProfile($"{playerName}.xml");
                Application.Current.Properties["currentPlayer"] = currentPlayer;
            }
            catch (XmlDeserializationException ex) 
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                playerProfileChoice.IsEnabled = false;
                playerProfileChoice.IsEnabled = true;
            }
        }
        /// <summary>
        /// Handles the startButton object
        /// </summary>
        /// <param name="sender">startButton in MainWindow</param>
        /// <param name="e">Button being clicked</param>
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            SecondWindow sw = new SecondWindow();
            sw.Show();
            this.Close();
        }
        /// <summary>
        /// Handles the DefaultPlayerStart object
        /// </summary>
        /// <param name="sender">DefaultPlayerStart button in MainWindow</param>
        /// <param name="e">Button being clicked</param>
        private void defaultPlayerStart_Click(object sender, RoutedEventArgs e)
        {
            bool playerState = true;
            Application.Current.Properties["playerState"] = playerState;
            DefaultPlayerProfile currentPlayer = new DefaultPlayerProfile();
            Application.Current.Properties["currentPlayer"] = currentPlayer;
            SecondWindow sw = new SecondWindow();
            sw.Show();
            this.Close();
        }
        /// <summary>
        /// Handles the musicButton object and the state of music playback
        /// </summary>
        /// <param name="sender">musicButton in MainWindow</param>
        /// <param name="e">Button being clicked</param>
        private void musicButton_Click(object sender, RoutedEventArgs e)
        {
            // Toggle pause/unpause state
            if (isMusicPaused)
            {
                // If paused, resume playback
                introMusic.Play();
                playingImage.Source = new BitmapImage(new Uri("https://i.etsystatic.com/38501418/r/il/a13085/4510104766/il_570xN.4510104766_2udh.jpg"));
            }
            else
            {
                // If playing, pause playback
                introMusic.Pause();
                playingImage.Source = new BitmapImage(new Uri("https://png.pngtree.com/png-vector/20190120/ourlarge/pngtree-stop-vector-icon-png-image_470720.jpg"));

            }

            // Update the state
            isMusicPaused = !isMusicPaused;
        }
        /// <summary>
        /// Handles the createButton object responsible for creating a new player profile
        /// </summary>
        /// <param name="sender">createButton in MainWindow</param>
        /// <param name="e">Button being clicked</param>
        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            if (newName == null)
                newName = string.Empty;
            try
            {
                if (Regex.IsMatch(newName, @"^[a-zA-Z]+$") && newName.Length <= 20 && newName != string.Empty)
                {
                    DBConnection.AddPlayer(newName);
                    DBPlayerProfile newPlayerProfile = new DBPlayerProfile(newName);
                    newPlayerProfile.numberOfWins = 0;
                    newPlayerProfile.numberOfLosses = 0;
                    SavePlayerProfile(newPlayerProfile, $"{newName}.xml");
                    refreshListBox();
                }
                else { throw new Exception("Incorrect name! It should be between 1 and 20 characters long and consist of letters only! Try again!"); }
            }
            catch (Exception ex) { newPlayerProfile.Text = ""; MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
        /// <summary>
        /// Handles the newPlayerProfile object responsible for getting user input 
        /// </summary>
        /// <param name="sender">newPlayerProfile textbox in MainWindow</param>
        /// <param name="e">Text being changed</param>
        private void newPlayerProfile_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            newName = textBox.Text;
            
        }
        /// <summary>
        /// Handles the showScore object, responsible for showing current player profile statistics
        /// </summary>
        /// <param name="sender">showScore button in MainWindow</param>
        /// <param name="e">Button being clicked</param>
        private void showScore_Click(object sender, RoutedEventArgs e)
        {
            bool playerState = (bool)Application.Current.Properties["playerState"];
            if (playerState)
            {
                DefaultPlayerProfile currentPlayer = (DefaultPlayerProfile)Application.Current.Properties["currentPlayer"];
                MessageBox.Show($"Default Player: Wins: {currentPlayer.numberOfWins}  Losses: {currentPlayer.numberOfLosses}");
            }
            else
            {
                DBPlayerProfile currentPlayer = (DBPlayerProfile)Application.Current.Properties["currentPlayer"];
                MessageBox.Show($"{currentPlayer.Name}: Wins: {currentPlayer.numberOfWins}  Losses: {currentPlayer.numberOfLosses}");
            }
        }
    }
}
