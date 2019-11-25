using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MadMaths.calculations;
using Newtonsoft.Json.Linq;

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

            if (!Controller.CheckSaveDir())
            {
                Controller.CreateSaveDir();
            }
            if (!Controller.CheckSaveFile())
            {
                Controller.CreateUserJS();
            }
            InitializeComponent();
            var c = CalcFunctions_Oberstufe.Ableiten6(2.0, 2.0, 3.0, 8.0, 1.0, 1.0);
            MessageBox.Show(c.ToString());
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

        /// TitleBar_MouseDown - Drag if single-click, resize if double-click
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                if (e.ClickCount == 2)
                {
                    AdjustWindowSize();
                }
                else { Application.Current.MainWindow.DragMove(); }
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
    }
}
