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
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        if (i < 3 || i > 4)
                        {
                            Image image = new Image();
                            BitmapImage source = new BitmapImage(new Uri("/checker.png", UriKind.Relative));
                            image.Source = source;
                            Grid.SetRow(image, i);
                            Grid.SetColumn(image, j);
                            grid.Children.Add(image);
                        }
                    }

                }
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
