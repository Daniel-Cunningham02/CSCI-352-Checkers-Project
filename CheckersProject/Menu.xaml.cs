﻿using CheckersProject.src;
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
            this.Icon = new BitmapImage(new Uri("..\\..\\CheckerRedTransparent.png", UriKind.Relative));
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void Local_Game_Click(object sender, RoutedEventArgs e)
        {
            Board b = new Board(GameType.LAN);
            this.Close();
            b.Show();
        }
        
        private void Multiplayer_Game_Click(object sender, RoutedEventArgs e)
        {
            MultiplayerMenu multiMenu = new MultiplayerMenu();
            multiMenu.Show();
            this.Close();
            
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
