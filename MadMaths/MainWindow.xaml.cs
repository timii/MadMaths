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

            if (!Controller.CheckSaveDir())
            {
                Controller.CreateSaveDir();
            }
            if (!Controller.CheckSaveFile())
            {
                Controller.CreateUserJS();
            }
            FileInfo fi = new FileInfo(Controller.UserSaveFile);
            fi.Attributes = FileAttributes.Normal;
            InitializeComponent();
            //MainFrame.Source = new Uri("pages/home.xaml", UriKind.Relative); // lädt Homescreen
        }

        ~MainWindow()
        {
            FileInfo fi = new FileInfo(Controller.UserSaveFile);
            fi.Attributes = FileAttributes.ReadOnly | FileAttributes.Hidden;
        }

        // Minimize Button Click
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // Maximize Button Click
        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            AdjustWindowSize();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void AdjustWindowSize()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                MaximizeButton.Content = "1";
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                MaximizeButton.Content = "2";
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
                else
                {
                    Application.Current.MainWindow.DragMove();
                }
        }
    }
}
