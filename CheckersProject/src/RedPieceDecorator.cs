using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CheckersProject.src
{
    internal class RedPieceDecorator : ABSPieceDecorator
    {

        public RedPieceDecorator(Piece c, Pos pos) : base(c) {
            Row = pos.Row;
            Column = pos.Column;
            BitmapImage source = new BitmapImage(new Uri("/CheckerRedTransparent.png", UriKind.Relative));
            i.Source = source;
        }
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
