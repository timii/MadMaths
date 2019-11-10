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
            FileInfo fi = new FileInfo(Controller.UserSaveFile);
            fi.Attributes = FileAttributes.Normal;

            if (!Controller.CheckSaveDir())
            {
                Controller.CreateSaveDir();
            }
            InitializeComponent();
            MainFrame.Source = new Uri("pages/home.xaml", UriKind.Relative); // lädt Homescreen
        }
        ~MainWindow()
        {
            FileInfo fi = new FileInfo(Controller.UserSaveFile);
            fi.Attributes = FileAttributes.ReadOnly | FileAttributes.Hidden;
        }
    }
}
