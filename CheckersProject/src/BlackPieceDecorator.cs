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
            if (Component == null)
            {
                Button button = (Button)b.grid.FindName("Button" + Row.ToString() + Column.ToString());
                button.Content = i;
            }
            else
            {
                UpdateComponent();
                Component.updateImage(b);
            }

        }


        public override void UpdateComponent()
        {
            Component.Row = Row;
            Component.Column = Column;
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

        public override bool CheckPromotion()
        {
            if (Component == null)
            {
                if (Row == 7)
                {
                    Component = new KingDecorator(null, new Pos(Row, Column), this.ToString());
                    return true;

                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}
