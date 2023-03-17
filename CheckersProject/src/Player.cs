using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CheckersProject;

namespace CheckersProject.src
{
    enum gameState
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
        private gameState _state;
        int pieceAmount;
        Board b;

        public Player(Board b)
        {
            _state = gameState.redTurn;
            this.b = b;
        }

        public void setPiece(Pos pos, Piece p)
        {
            board[pos.Row, pos.Column] = p;
        }

        public void update()
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null)
                    {
                        b.setPieceImage(new Pos(i, j), board[i, j].ToString());
                    }
                }
            }
        }
    }
}
