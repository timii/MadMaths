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
            UserName.ContextMenu = UserPassword.ContextMenu = null;     // deaktiviert das Context Menü, um das Einfügen von ungültigen Benutzernamen und Passwörtern zu unterbinden
        }

        private void UserName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // überprüft, ob Leerzeichen vorkommen
            if (e.Key == Key.Space && UserName.IsFocused == true) { e.Handled = true; }
            if (UserName.Text.Length >= 12 && e.Key != Key.Back)
            {
                e.Handled = true;
                UsernameFeedback.Text = "Name zu lang (maximal 12 Zeichen)";
            }
            else { UsernameFeedback.Text = ""; }
            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) { e.Handled = true; }    // unterbindet das Copy&Paste von ungültigen Passwörtern
        }

        private void UserPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // überprüft, ob Leerzeichen vorkommen
            if (e.Key == Key.Space && UserPassword.IsFocused == true) { e.Handled = true; }
            if (UserPassword.Password.Length >= 16 && e.Key != Key.Back)
            {
                e.Handled = true;
                PasswordFeedback.Text = "Passwort zu lang (maximal 16 Zeichen)";
            }
            else { PasswordFeedback.Text = ""; }
            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) { e.Handled = true; }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            UsernameFeedback.Text = "";
            PasswordFeedback.Text = "";
            if (UserPassword.Password.Length >= 8 && UserName.Text.Length >= 2)
            {
                if (Client.CheckUsername(UserName.Text))
                {
                    Controller.user.UserName = UserName.Text;
                    Controller.user.password = GetHashString(UserPassword.Password);
                    Task.Run(() => Client.RegisterUser(Controller.user.UserName, Controller.user.password));
                    Controller.UpdateUserJson();
                    NavigationService.Navigate(new home());
                }
                else { UsernameFeedback.Text = "Benutzername existiert bereits"; }
            }
            else
            {
                if (UserPassword.Password.Length < 8) PasswordFeedback.Text = "Passwort ist zu kurz (mind. 8 Zeichen)";
                if (UserName.Text.Length < 2) UsernameFeedback.Text = "Benutzername zu kurz (mind. 2 Zeichen)";
            }
        }

        private void ThemenBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            var hashedpw = algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            algorithm.Dispose(); algorithm.Clear();
            return hashedpw;
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
            if (UserPassword.Password.Length >= 8 && UserName.Text.Length >= 2)
            {
                Login.IsEnabled = Register.IsEnabled = BackButton.IsEnabled = false;
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
                    Login.IsEnabled = Register.IsEnabled = BackButton.IsEnabled = true;
                    Cursor = Cursors.Arrow;
                }
            }
            else
            {
                if (UserPassword.Password.Length < 8) PasswordFeedback.Text = "Passwort ist zu kurz (mind. 8 Zeichen)";
                if (UserName.Text.Length < 2) UsernameFeedback.Text = "Benutzername zu kurz (mind. 2 Zeichen)";
            }
        }
    }
}
