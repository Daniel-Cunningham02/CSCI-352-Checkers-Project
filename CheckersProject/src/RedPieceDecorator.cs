using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CheckersProject.src
{
    /*internal class RedPieceDecorator : ABSPieceDecorator
    {

        public RedPieceDecorator(Piece c) : base(c) {
            BitmapImage source = new BitmapImage(new Uri("/CheckerRedTransparent.png", UriKind.Relative));
            i.Source = source;
        }
        public override void checkValidMoves()
        {

        }
        public override void updateImage(Board b)
        {
            Image temp = new Image();
            temp.Source = i.Source;
            Grid.SetRow(temp, Row);
            Grid.SetColumn(temp, Column);
            i = temp;
            Grid.SetRow(i, Row);
            Grid.SetColumn(i, Column);
            b.grid.Children.Add(i);

        }

        public override Image getImage()
        {
            return i;
        }
    }*/
}
