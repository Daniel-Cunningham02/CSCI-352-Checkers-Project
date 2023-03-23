﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CheckersProject.src;
using System.Threading;
using System.Linq.Expressions;
using System.Runtime.Remoting.Channels;

namespace CheckersProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Board : Window
    {
        public Board()
        {
            Dictionary<string, Thread> threadMap= new Dictionary<string, Thread>();
            InitializeComponent();
            Player player = new Player(this);
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        // Creates button and adds it to the grid along with its color.
                        Button button = new Button();
                        button.Name = "Button" + i + j;
                        button.Background = Brushes.Black;
                        button.Click += new RoutedEventHandler(Move_Button_Click);
                        Grid.SetRow(button, i);
                        Grid.SetColumn(button, j);
                        grid.Children.Add(button);


                        if (i < 3) 
                        {


                            BlackPieceDecorator piece = new BlackPieceDecorator(null);
                            player.setPiece(new Pos(i, j), piece);
                            /*Image image = new Image();
                            BitmapImage source = new BitmapImage(new Uri("/checker.png", UriKind.Relative));
                            image.Source = source;
                            Grid.SetRow(image, i);
                            Grid.SetColumn(image, j);
                            grid.Children.Add(image);*/
                        }
                        else if(i > 4)
                        {
                            
                        }
                        else
                        {
                            player.setPiece(new Pos(i, j), null);
                        }
                    }
                    else
                    {
                        // Creating button here too
                        Button button = new Button();
                        button.Name = "Button" + i + j;
                        button.Background = Brushes.Red;
                        button.Click += new RoutedEventHandler(Move_Button_Click); // Creates new EventHandler for the button because there is not a handler made automatically.
                        Grid.SetRow(button, i);
                        Grid.SetColumn(button, j);
                        grid.Children.Add(button);


                        player.setPiece(new Pos(i, j), null);
                    }

                }
            }
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void Move_Button_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = "Hit"; // Changes the content of the button to hit.
        }
        private void Quit_Button_Click(object sender, RoutedEventArgs e)
        {
            
            Menu m  = new Menu();
            this.Close();
            m.Show();
        }
    }
}
