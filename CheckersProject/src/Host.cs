using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersProject.src
{
    internal class Host : Player
    {
        public Host(Board b) : base(b)
        {

        }

        override public void HighlightValidMoves(Piece p)
        {

        }
        override public void ResetHighlights(Piece p)
        {

        }
        override public void CheckValidMoves(Piece p)
        {

        }

        override public bool Move(Pos pos, Piece p)
        {
            return false;
        }
        override public void SetPiece(Pos pos, Piece p)
        {

        }

        override public Piece GetPiece(Pos pos)
        {
            return null;
        }
    }
}
