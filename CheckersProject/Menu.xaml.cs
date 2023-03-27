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

namespace CheckersProject
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void Local_Game_Click(object sender, RoutedEventArgs e)
        {
            Board b = new Board();
            this.Close();
            b.Show();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
