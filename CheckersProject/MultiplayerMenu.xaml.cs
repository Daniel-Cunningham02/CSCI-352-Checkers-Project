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
    /// Interaction logic for MultiplayerMenu.xaml
    /// </summary>
    public partial class MultiplayerMenu : Window
    {
        Board board;
        public MultiplayerMenu(Board b)
        {
            board = b;
            InitializeComponent();
        }

        private void Host_Click(object sender, RoutedEventArgs e)
        {
            board.player //TODO: Need to somehow get click and return HOST player type to the board
        }

        private void Join_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Need to somehow get click and return Joined player type to the board
        }

    }
}
