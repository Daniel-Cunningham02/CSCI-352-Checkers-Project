using CheckersProject.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private string IP;
        public MultiplayerMenu()
        {
            IP = "127.0.0.1:8080";
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void Host_Click(object sender, RoutedEventArgs e)
        {
            Board b = new Board(GameType.MultiplayerHost);
            b.Show();
            this.Close();
        }

        private void Join_Click(object sender, RoutedEventArgs e)
        {
            Board b = new Board(GameType.MultiplayerJoin);
            b.Show();
            this.Close();
            //TODO: Need to somehow get click and return Joined player type to the board
        }

        private void Ip_TextChanged(object sender, TextChangedEventArgs e)
        {
            IP = Ip.Text;
        }
    }
}
