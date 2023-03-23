using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CheckersProject.src
{
    enum GameState
    {
        unstarted,
        redTurn,
        blackTurn,
        redWin,
        blackWin,
        redForfeit,
        blackForfeit,
    }
    internal class Player
    {
        private Piece[,] board = new Piece[8, 8];
        private GameState _state;
        readonly Board B;

        public Player(Board b)
        {
            B = b;
        }
        public void Move(Pos pos, Piece p)
        {

        }

        public void SetPiece(Pos pos, Piece p)
        {
            board[pos.Row, pos.Column] = p;
            p.updateImage(B);
        }

    }
}
