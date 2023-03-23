using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersProject.src
{
    internal abstract class ABSPieceDecorator : Piece
    {
        private Piece component;

        public ABSPieceDecorator(Piece c)
        {
            this.component = c;
        }
    }
}
