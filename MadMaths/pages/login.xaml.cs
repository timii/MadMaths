using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

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
            if (!Controller.UserIsOnline) { Login.IsEnabled = false; }
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
                Controller.user.UserName = UserName.Text;
                if (UserPassword.Password.Length < 8)
                {
                    PasswordFeedback.Text = "Passwort ist zu kurz (mind. 8 Zeichen)";
                    return;
                }
                Controller.user.password = GetHashString(UserPassword.Password);
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

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            Login.IsEnabled = false; Register.IsEnabled = false;
            BackButton.IsEnabled = false;
            Cursor = Cursors.Wait;
            string pw = GetHashString(UserPassword.Password);
            if (Client.LoginUser(UserName.Text, pw))
            {
                Controller.user.UserName = UserName.Text;
                Controller.user.password = pw;
                await Client.GetUserData();
                NavigationService.Navigate(new home());
            }
            else
            {
                UsernameFeedback.Text = "Benutzername oder Passwort ist falsch";
                Login.IsEnabled = true; Register.IsEnabled = true;
                BackButton.IsEnabled = true;
                Cursor = Cursors.Arrow;
            }
        }
    }
}
