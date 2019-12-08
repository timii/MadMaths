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
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void Logoutclick(object sender, RoutedEventArgs e)
        {
            Controller.UserIsLoggedIn = false;
            Controller.user = new User();
            Client.UpdateUserData("LEVEL");
            Client.LogoutUser();
            DialogResult = true;
            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) // FIXME Close Button funktioniert nicht
        {
            DialogResult = false;
            Close();
        }
    }
}
