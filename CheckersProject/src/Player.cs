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
        Board b;

        public Player(Board b)
        {
            _state = gameState.redTurn;
            this.b = b;
        }
        public void move(Pos pos, Piece p)
        {
            board[p.Row, p.Column] = null;
            board[pos.Row, pos.Column] = p;
            p.Row = pos.Row;
            p.Column = pos.Column;
            b.grid.Children.Remove(p.getImage());
            p.updateImage(b);
            b.grid.Children.Add(p.getImage());
        }

        public void setPiece(Pos pos, Piece p)
        {
            board[pos.Row, pos.Column] = p;
            p.Row = pos.Row;
            p.Column = pos.Column;
        }

        public void update()
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null)
                    {
                        board[i, j].updateImage(b);
                        
                       /*b.esetPieceImag(new Pos(i, j), board[i, j].ToString());*/
                    }
                    else if (board[i, j] == null)
                    {
                        b.grid.Children.RemoveAt((i*8) + j);
                        //b.setPieceImage(new Pos(i, j), "null");
                    }
                }
            }
        }
    }
}
