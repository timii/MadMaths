using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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

namespace MadMaths.pages
{
    /// <summary>
    /// Interaktionslogik für login.xaml
    /// </summary>
    public partial class login : Page
    {
        public login()
        {
            InitializeComponent();
        }

        private void UserPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // überprüft, ob Leerzeichen vorkommen
            if (e.Key == Key.Space && UserPassword.IsFocused == true) { e.Handled = true; }
        }

        private void UserName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // überprüft, ob Leerzeichen vorkommen
            if (e.Key == Key.Space && UserName.IsFocused == true) { e.Handled = true; }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            UsernameFeedback.Text = "";
            PasswordFeedback.Text = "";
            if (Client.CheckUsername(UserName.Text))
            {
                Controller._user.UserName = UserName.Text;
                if (UserPassword.Password.Length < 8) 
                {
                    PasswordFeedback.Text = "Passwort ist zu kurz (mind. 8 Zeichen)";
                    return;
                }
                Controller._user.password = GetHashString(UserPassword.Password);
                Client.RegisterUser(UserName.Text, GetHashString(UserPassword.Password));
                Controller.UpdateUserJson();
                NavigationService.GoBack();
            }
            else
            {
                UsernameFeedback.Text = "Benutzername existiert bereits";
            }
        }
        private void ThemenBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack(); // geht eine Seite zurück
        }
        private byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        private string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
    }
}
