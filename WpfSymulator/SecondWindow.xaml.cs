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
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        /// <summary>
        /// Fields responsible for a list of clubs and the users club of choice
        /// </summary>
        public static List<Club> wszystkieKluby = new List<Club>();
        public static Club userPick  = new Club();
        
        /// <summary>
        /// Initialises the SecondWindow
        /// </summary>
        public SecondWindow()
        {
            InitializeComponent();
            wszystkieKluby = MainWindow.wszystkieKluby;
            userPick = new Club();
            topMusic.Play();
            
        }
        /// <summary>
        /// Handles the RealMadrit object, updates userPick and opens a new ThirdWindow
        /// </summary>
        /// <param name="sender">RealMadrit button in SecondWindow</param>
        /// <param name="e">Button being clicked</param>
        private async void RealMadrit_Click(object sender, RoutedEventArgs e)
        {
            userPick = wszystkieKluby.FirstOrDefault(club => club.Nazwa == "Real Madrit");
            if (userPick != null)
            {
                DisableButtons();
                wyborDruzyny.Text = "CHOSEN TEAM: " + userPick.Nazwa;
                wszystkieKluby.Remove(userPick);
                await Task.Delay(3000);
                ThirdWindow tw = new ThirdWindow();
                tw.Show();
                this.Close();
            }

        }

        /// <summary>
        /// Handles the FCBarcelona object, updates userPick and opens a new ThirdWindow
        /// </summary>
        /// <param name="sender">FCBarcelona button in SecondWindow</param>
        /// <param name="e">Button being clicked</param>
        private async void FCBarcelona_Click(object sender, RoutedEventArgs e)
        {
            userPick = wszystkieKluby.FirstOrDefault(club => club.Nazwa == "FC Barcelona");
            if (userPick != null)
            {
                DisableButtons();
                wyborDruzyny.Text = "CHOSEN TEAM: " + userPick.Nazwa;
                wszystkieKluby.Remove(userPick);
                await Task.Delay(3000);
                ThirdWindow tw = new ThirdWindow();
                tw.Show();
                this.Close();
            }
        }
        /// <summary>
        /// Handles the ManchesterCity object, updates userPick and opens a new ThirdWindow
        /// </summary>
        /// <param name="sender">ManchesterCity button in SecondWindow</param>
        /// <param name="e">Button being clicked</param>
        private async void ManchesterCity_Click(object sender, RoutedEventArgs e)
        {
            userPick = wszystkieKluby.FirstOrDefault(club => club.Nazwa == "Manchester City");
            if (userPick != null)
            {
                DisableButtons();
                wyborDruzyny.Text = "CHOSEN TEAM: " + userPick.Nazwa;
                wszystkieKluby.Remove(userPick);
                await Task.Delay(3000);
                ThirdWindow tw = new ThirdWindow();
                tw.Show();
                this.Close();
            }
        }
        /// <summary>
        /// Handles the ManchesterUnited object, updates userPick and opens a new ThirdWindow
        /// </summary>
        /// <param name="sender">ManchesterUnited button in SecondWindow</param>
        /// <param name="e">Button being clicked</param>
        private async void ManchesterUnited_Click(object sender, RoutedEventArgs e)
        {
            userPick = wszystkieKluby.FirstOrDefault(club => club.Nazwa == "Manchester United");
            if (userPick != null)
            {
                DisableButtons();
                wyborDruzyny.Text = "CHOSEN TEAM: " + userPick.Nazwa;
                wszystkieKluby.Remove(userPick);
                await Task.Delay(3000);
                ThirdWindow tw = new ThirdWindow();
                tw.Show();
                this.Close();
            }
        }
        /// <summary>
        /// Handles the PSG object, updates userPick and opens a new ThirdWindow
        /// </summary>
        /// <param name="sender">PSG button in SecondWindow</param>
        /// <param name="e">Button being clicked</param>
        private async void PSG_Click(object sender, RoutedEventArgs e)
        {
            userPick = wszystkieKluby.FirstOrDefault(club => club.Nazwa == "PSG");
            if (userPick != null)
            {
                DisableButtons();
                wyborDruzyny.Text = "CHOSEN TEAM: " + userPick.Nazwa;
                wszystkieKluby.Remove(userPick);
                await Task.Delay(3000);
                ThirdWindow tw = new ThirdWindow();
                tw.Show();
                this.Close();
            }
        }
        /// <summary>
        /// Handles the Liverpool object, updates userPick and opens a new ThirdWindow
        /// </summary>
        /// <param name="sender">Liverppol button in SecondWindow</param>
        /// <param name="e">Button being clicked</param>
        private async void Liverpool_Click(object sender, RoutedEventArgs e)
        {
            userPick = wszystkieKluby.FirstOrDefault(club => club.Nazwa == "Liverpool");
            if (userPick != null)
            {
                DisableButtons();
                wyborDruzyny.Text = "CHOSEN TEAM: " + userPick.Nazwa;
                wszystkieKluby.Remove(userPick);
                await Task.Delay(3000);
                ThirdWindow tw = new ThirdWindow();
                tw.Show();
                this.Close();
            }
        }
        /// <summary>
        /// Handles the FCBayern object, updates userPick and opens a new ThirdWindow
        /// </summary>
        /// <param name="sender">FCBayern button in SecondWindow</param>
        /// <param name="e">Button being clicked</param>
        private async void FCBayern_Click(object sender, RoutedEventArgs e)
        {
            userPick = wszystkieKluby.FirstOrDefault(club => club.Nazwa == "FC Bayern");
            if (userPick != null)
            {
                DisableButtons();
                wyborDruzyny.Text = "CHOSEN TEAM: " + userPick.Nazwa;
                wszystkieKluby.Remove(userPick);
                await Task.Delay(3000);
                ThirdWindow tw = new ThirdWindow();
                tw.Show();
                this.Close();
            }
        }
        /// <summary>
        /// Handles the WislaKrakow object, updates userPick and opens a new ThirdWindow
        /// </summary>
        /// <param name="sender">WislaKrakow button in SecondWindow</param>
        /// <param name="e">Button being clicked</param>
        private async void WislaKrakow_Click(object sender, RoutedEventArgs e)
        {
            topMusic.Pause();
            wislaMusic.Play();
            userPick = wszystkieKluby.FirstOrDefault(club => club.Nazwa == "Wisla Krakow");
            if (userPick != null)
            {
                DisableButtons();
                wyborDruzyny.Text = "CHOSEN TEAM: " + userPick.Nazwa;
                wszystkieKluby.Remove(userPick);
                await Task.Delay(15000);
                ThirdWindow tw = new ThirdWindow();
                tw.Show();
                this.Close();
            }
        }
        /// <summary>
        /// Method responsible for disabling all buttons 
        /// </summary>
        private void DisableButtons()
        {
            RealMadrit.IsEnabled = false;
            FCBarcelona.IsEnabled = false;
            ManchesterCity.IsEnabled = false;
            ManchesterUnited.IsEnabled = false;
            PSG.IsEnabled = false;
            Liverpool.IsEnabled = false;
            FCBayern.IsEnabled = false;
            WislaKrakow.IsEnabled = false;
        }
    }
}
