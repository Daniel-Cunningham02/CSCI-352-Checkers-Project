using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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

        public Player()
        {

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
            if (_state == gameState.redTurn)
                _state = gameState.blackTurn;
            else if(_state == gameState.blackTurn)
                _state = gameState.redTurn;
        }

        public void setPiece(Pos pos, Piece p)
        {
            board[pos.Row, pos.Column] = p;
            p.Row = pos.Row;
            p.Column = pos.Column;
        }

        public void printBoard()
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (board[i, j] == null)
                    {
                        TextBox text = new TextBox();
                        text.Text = board[i, j].ToString();
                        Grid.SetRow(text, i);
                        Grid.SetRow(text, j);
                        Board.grid.Children.Add(text);
                    }
                    else if (board[i, j] != null)
                    {
                        
                    }
                }
            }
        }
    }
}
