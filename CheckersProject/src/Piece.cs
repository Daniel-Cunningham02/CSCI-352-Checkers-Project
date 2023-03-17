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
        public int Column { get { return row; } set {this.column = value; } }
        protected Image i = new Image();
        abstract public void checkValidMoves();

        abstract public void updateImage(Board b);

        abstract public Image getImage();
    }
}
