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

        public void setPiece(Pos pos, Piece p)
        {
            board[pos.Row, pos.Column] = p;
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
