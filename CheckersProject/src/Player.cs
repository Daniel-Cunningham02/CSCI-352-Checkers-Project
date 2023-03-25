using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public void CheckValidMoves(Piece p) // Started working on this and decided to do it later.
        { 
            /*if(p.ToString() == "CheckersProject.src.BlackPieceDecorator")
            {
                if(p.Row + 1 < 8 && p.Row + 1 >= 0)
                {
                    Button button;
                    if (p.Column + 1 < 8 && p.Column + 1 >= 0)
                    {
                        Image i = p.getImageClone();
                        button = (Button)B.grid.FindName("Button" + (p.Row + 1) + (p.Column + 1));
                        i.Opacity = 0.5;
                        button.Content = i;
                    }
                    if (p.Column - 1 < 8 && p.Column - 1 >= 0)
                    {
                        Image i = p.getImageClone();
                        button = (Button)B.grid.FindName("Button" + (p.Row + 1) + (p.Column - 1));
                        i.Opacity = 0.5;
                        button.Content = i;
                    }
                }
            }*/
        }
        public void Move(Pos pos, Piece p)
        {
            /* For now, this is just a really complicated swap afterwards it updates both of the images*/
            if (p != null && board[pos.Row, pos.Column] != null)
            {
                Piece temp = board[pos.Row, pos.Column];
                board[pos.Row, pos.Column] = p;
                board[p.Row, p.Column] = temp;
                board[p.Row, p.Column].Row = p.Row;
                board[p.Row, p.Column].Column = p.Column;
                temp = board[p.Row, p.Column];
                p.Row = pos.Row;
                p.Column = pos.Column;

                temp.updateImage(B);
                p.updateImage(B);
            }

        }

        public void SetPiece(Pos pos, Piece p)
        {
            board[pos.Row, pos.Column] = p;
            p.updateImage(B); 
            /* updateImage just takes the Board xaml, finds the button linked to the piece,
             * and changes the button's content to the correct image*/
        }

        public Piece GetPiece(Pos pos)
        {
            return board[pos.Row, pos.Column];
        }

    }
}
