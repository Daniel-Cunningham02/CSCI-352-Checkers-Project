using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersProject.src
{
    internal class Move
    {
        Pos position;
        Piece piece;
        public Move(Pos pos, Piece p)
        {
            position = pos;
            piece = p;
        }
    }
}
