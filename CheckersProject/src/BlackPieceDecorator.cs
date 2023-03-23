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


        public override void updateImage(Board b)
        {
            Button button = (Button)b.grid.FindName("Button" + Row.ToString() + Column.ToString());
            button.Content = i;
            

        }

        public override Image getImage()
        {
            return i;
        }

        public override void SetValidMoves(List<Pos> validMoves)
        {
            ValidMoves = validMoves;
        }

        public override Image getImageClone()
        {
            Image image2 = new Image();
            image2.Source = i.Source;
            return image2;
        }
    }
}
