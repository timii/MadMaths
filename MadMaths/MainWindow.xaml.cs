using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace MadMaths
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Controller.UserIsOnline) { onlineStatus.Content = "verbunden"; }
            else { onlineStatus.Content = "nicht verbunden"; }
            MainFrame.Source = new Uri("pages/home.xaml", UriKind.Relative); // lädt Homescreen

        }

        // Minimize Button Click
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        { this.WindowState = WindowState.Minimized; }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Controller.UpdateUserJson();
            if (Client.client != null)
            {
                Client.UpdateUserData("LEVEL");
                Client.client.Close();
            }
            Application.Current.Shutdown();
        }

        /// TitleBar_MouseDown - Drag if single-click
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Application.Current.MainWindow.DragMove();
            }
        }

        public static void updateStatus(in string status)
        {
            MainWindow mainwin = Application.Current.MainWindow as MainWindow;
            mainwin.onlineStatus.Content = status;
        }
    }
}
