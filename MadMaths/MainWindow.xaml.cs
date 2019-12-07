﻿using System;
using System.IO;
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

            if (!Controller.CheckSaveDir())
            {
                Controller.CreateSaveDir();
            }
            if (!Controller.CheckSaveFile())
            {
                Controller.CreateUserJS();
            }
            else 
            {
                if (!Client.LoginUser())
                {
                    new CustomMB("Falscher Benutzername oder Passwort").ShowDialog();
                }
            }
            //Client.GetRanklist();
            InitializeComponent();
            MainFrame.Source = new Uri("pages/home.xaml", UriKind.Relative); // lädt Homescreen
        }

        ~MainWindow()
        {
            Client.UpdateUserData("LEVEL");
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
    }
}
