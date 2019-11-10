using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (e.Key == Key.Space && UserPassword.IsFocused == true){e.Handled = true;}
        }

        private void UserName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // überprüft, ob Leerzeichen vorkommen
            if (e.Key == Key.Space && UserName.IsFocused == true) {e.Handled = true;}
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.UserName = UserName.Text;
            user.password = UserPassword.Password;
            using (StreamWriter file = new StreamWriter(File.Open(Controller.UserSaveFile, FileMode.Open)))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, user);
            }
            NavigationService.GoBack();
        }
    }
}
