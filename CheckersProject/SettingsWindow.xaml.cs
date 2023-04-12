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
            this.Icon = new BitmapImage(new Uri("..\\..\\CheckerRedTransparent.png", UriKind.Relative));
            InitializeComponent();
        }

        private void RedButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = f.GetSquare(Enum.Red).changeColor();
            Menu m = new Menu(b);
            this.Close();
            m.Show();
            
        }

        private void BlueButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = f.GetBlueSquare().changeColor();
            Menu m = new Menu(b);
            this.Close();
            m.Show();
        }

        /**private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Menu m = new Menu(null);
            this.Close();
            m.Show();
        }**/ 

        private void PurpleButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = f.GetPurpleSquare().changeColor();
            Menu m = new Menu(b);
            this.Close();
            m.Show();

        }

        private void MagentaButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = f.GetMagentaSquare().changeColor();
            Menu m = new Menu(b);
            this.Close();
            m.Show();

        }

        private void WhiteButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = f.GetWhiteSquare().changeColor();
            Menu m = new Menu(b);
            this.Close();
            m.Show();

        }

        private void IndigoButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = f.GetIndigoSquare().changeColor();
            Menu m = new Menu(b);
            this.Close();
            m.Show();

        }
    }
}
