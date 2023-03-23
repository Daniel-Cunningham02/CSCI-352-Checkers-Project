using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CheckersProject.src
{
    internal class KingDecorator : ABSPieceDecorator
    {

        public KingDecorator(Piece c) : base(c) { }
        
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
