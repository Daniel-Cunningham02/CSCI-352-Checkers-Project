using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CheckersProject.src
{
    internal class BlackPieceDecorator : ABSPieceDecorator
    {
        public BlackPieceDecorator(Piece c) : base(c) { }

        public override void move(Pos pos)
        {
            
        }

        public override void checkValidMoves()
        {
             
        }
    }
}
