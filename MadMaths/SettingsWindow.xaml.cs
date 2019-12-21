using MadMaths.pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MadMaths
{
    /// <summary>
    /// Interaktionslogik für SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public static bool IsSoundOn = true;
        public SettingsWindow()
        {
            InitializeComponent();
            if (!Controller.UserIsLoggedIn)
            {
                logoutbtn.IsEnabled = false;
            }
            if (IsSoundOn) soundbtn.Content = "Sound on";
            else soundbtn.Content = "Sound off";
        }

        private void Logoutclick(object sender, RoutedEventArgs e)
        {
            Controller.UserIsLoggedIn = false;
            Client.UpdateUserData("LEVEL");
            Client.LogoutUser();
            Controller.user = new User();
            Controller.UpdateUserJson();
            DialogResult = true;
            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) // FIXME Close Button funktioniert nicht
        {
            DialogResult = false;
            Close();
        }

        private void Soundbtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsSoundOn)
            {
                IsSoundOn = false;
                soundbtn.Content = "Sound off";
            }
            else
            {
                IsSoundOn = true;
                soundbtn.Content = "Sound on";
            }
        }
    }
}
