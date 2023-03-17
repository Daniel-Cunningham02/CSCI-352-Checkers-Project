using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersProject.src
{
    internal class RedPieceDecorator : ABSPieceDecorator
    {

        public RedPieceDecorator(Piece c) : base(c) { }
        public override void checkValidMoves()
        {
            
        }

        public override void move(Pos pos)
        {
            throw new NotImplementedException();
        }
    }
}
