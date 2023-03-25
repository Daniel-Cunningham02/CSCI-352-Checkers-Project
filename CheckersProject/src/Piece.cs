using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CheckersProject.src
{
    internal abstract class Piece
    {
        private List<Pos> validMoves;
        private int row, column;
        public int Row { get { return row; } set { this.row = value; } }
        public int Column { get { return column; } set {this.column = value; } }

        public List<Pos> ValidMoves { get { return validMoves; } set { this.validMoves = value; } }
        protected Image i = new Image();

        abstract public void updateImage(Board b);

        abstract public Image getImage();

        abstract public Image getImageClone();

        abstract public void SetValidMoves(List<Pos> validMoves);
        abstract public bool CheckPromotion();

        abstract public void UpdateComponent();
    }
}
