using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CheckersProject.src
{
    internal abstract class Piece
    {
        private List<Pos> validMoves;
        abstract public void move(Pos pos);
    }
}
