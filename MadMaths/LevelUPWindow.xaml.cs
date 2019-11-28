using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MadMaths
{
    /// <summary>
    /// Interaktionslogik für LevelUPWindow.xaml
    /// </summary>
    public partial class LevelUpWindow : Window
    {
        public LevelUpWindow(string lvl)
        {
            InitializeComponent();
            LevelPopUp.Text = lvl;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
