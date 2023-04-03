using CheckersProject.src;
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
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        Factory f = new Factory();

        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void RedButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = f.GetRedSquare().changeColor();
            Board board = new Board(b);
            this.Close();
            board.Show();
            
        }

        private void BlueButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = f.GetBlueSquare().changeColor();
            Board board = new Board(b);
            this.Close();
            board.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Menu m = new Menu();
            this.Close();
            m.Show();
        }

        private void PurpleButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = f.GetPurpleSquare().changeColor();
            Board board = new Board(b);
            this.Close();
            board.Show();

        }
    }
}
