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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CheckersProject.src;

namespace CheckersProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Board : Window
    {
        public Board()
        {
            InitializeComponent();
            Grid myGrid = grid;
            Player player = new Player(this);
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        if (i < 3) 
                        {
                            BlackPieceDecorator piece = new BlackPieceDecorator(null);
                            player.setPiece(new Pos(i, j), piece);
                        }
                        else if(i > 4)
                        {
                            RedPieceDecorator piece = new RedPieceDecorator(null);
                            player.setPiece(new Pos(i, j), piece);
                        }
                        else
                        {
                            player.setPiece(new Pos(i, j), null);
                        }
                    }
                    else
                    {
                        player.setPiece(new Pos(i, j), null);
                    }

                }
            }
            this.ResizeMode = ResizeMode.NoResize;
            player.update();
        }

        public void setPieceImage(Pos pos, string type)
        {
            if(type == "CheckersProject.src.RedPieceDecorator")
            {
                Image image = new Image();
                BitmapImage source = new BitmapImage(new Uri("/CheckerRedTransparent.png", UriKind.Relative));
                image.Source = source;
                Grid.SetRow(image, pos.Row);
                Grid.SetColumn(image, pos.Column);
                grid.Children.Add(image);
            }
            else
            {
                Image image = new Image();
                BitmapImage source = new BitmapImage(new Uri("/CheckerBlueTransparent.png", UriKind.Relative));
                image.Source = source;
                Grid.SetRow(image, pos.Row);
                Grid.SetColumn(image, pos.Column);
                grid.Children.Add(image);
            }
        }

        private void Quit_Button_Click(object sender, RoutedEventArgs e)
        {
            Menu m  = new Menu();
            this.Close();
            m.Show();
        }
    }
}
