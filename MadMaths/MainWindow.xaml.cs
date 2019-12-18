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
            SourceInitialized += (s, e) =>
            {
                IntPtr handle = (new WindowInteropHelper(this)).Handle;
                HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(CustomWindowSizing.WindowProc));
            };

            Controller.CreateRankList();
            InitializeComponent();
            if (Controller.UserIsOnline) { onlineStatus.Content = "verbunden"; }
            else { onlineStatus.Content = "nicht verbunden"; }
            MainFrame.Source = new Uri("pages/home.xaml", UriKind.Relative); // lädt Homescreen
        }

        // Minimize Button Click
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        { this.WindowState = WindowState.Minimized; }

        // Maximize Button Click
        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        { AdjustWindowSize(); }

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
        private void AdjustWindowSize()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                MaximizeButton.Style = Application.Current.FindResource("WindowButtonMaximize") as Style;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                MaximizeButton.Style = Application.Current.FindResource("WindowButtonMinimize") as Style;
            }
        }

        /// TitleBar_MouseDown - Drag if single-click
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Application.Current.MainWindow.DragMove();
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                MaximizeButton.Style = Application.Current.FindResource("WindowButtonMinimize") as Style;
            }
            else if (this.WindowState == WindowState.Normal)
            {
                MaximizeButton.Style = Application.Current.FindResource("WindowButtonMaximize") as Style;
            }
        }

        public static void updateStatus(in string status)
        {
            MainWindow mainwin = Application.Current.MainWindow as MainWindow;
            mainwin.onlineStatus.Content = status;
        }
    }
}
