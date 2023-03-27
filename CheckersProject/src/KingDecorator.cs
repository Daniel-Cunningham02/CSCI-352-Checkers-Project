using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CheckersProject.src
{
    internal class KingDecorator : ABSPieceDecorator
    {

        public KingDecorator(Piece c, Pos pos, string PieceType) : base(c) {
            if(PieceType == "CheckersProject.src.BlackPieceDecorator")
            {
                i.Source = new BitmapImage(new Uri("/BlueKing.png", UriKind.Relative));
            }
            else if(PieceType == "CheckersProject.src.RedPieceDecorator")
            {
                i.Source = new BitmapImage(new Uri("/RedKing.png", UriKind.Relative));
            }
        }
        
        public override void updateImage(Board b)
        {
            Button button = (Button)b.grid.FindName("Button" + Row.ToString() + Column.ToString());
            button.Content = i;

        }

        public override void UpdateComponent()
        {
        }

        public override Piece GetComponent()
        {
            return null;
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
            return false;
        }
    }
}
