using System.Windows;

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
            if (IsSoundOn) soundbtn.Content = "Ton an";
            else soundbtn.Content = "Ton aus";
        }

        private void Logoutclick(object sender, RoutedEventArgs e)
        {
            Controller.UserIsLoggedIn = false;
            Client.UpdateUserData("LEVEL");
            Client.LogoutUser();
            var temp = Controller.user.lastSessions;
            Controller.user = new User();
            Controller.user.lastSessions = temp;
            Controller.UpdateUserJson();
            DialogResult = true;
            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Soundbtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsSoundOn)
            {
                IsSoundOn = false;
                soundbtn.Content = "Ton aus";
            }
            else
            {
                IsSoundOn = true;
                soundbtn.Content = "Ton an";
            }
        }
    }
}
