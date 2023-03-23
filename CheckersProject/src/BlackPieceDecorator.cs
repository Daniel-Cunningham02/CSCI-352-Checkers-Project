using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CheckersProject.src
{
    internal class BlackPieceDecorator : ABSPieceDecorator
    {
        public BlackPieceDecorator(Piece c, Pos pos) : base(c) {
            Row = pos.Row;
            Column = pos.Column;
            BitmapImage source = new BitmapImage(new Uri("/CheckerBlueTransparent.png", UriKind.Relative));
            i.Source = source;
        }

        /*public override void show(Pos pos, Board b)
        {
            Grid.SetRow(i, pos.Row);
            Grid.SetColumn(i, pos.Column);
            b.grid.Children.Add(i);
        }*/

        public override void checkValidMoves()
        {
             
        }

        public override void updateImage(Board b)
        {
            Button button = (Button)b.grid.FindName("Button" + Row.ToString() + Column.ToString());
            button.Content = i;
            

        }

        public override Image getImage()
        {
            return i;
        }
    }
}
