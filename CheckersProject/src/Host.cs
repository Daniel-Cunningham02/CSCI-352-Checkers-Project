using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CheckersProject.src
{
    internal class Host : Player
    {
        Observer observer;
        public Host(Board b) : base(b)
        {
            observer = new Observer();
            observer.Attach(this);
        }

        public Observer getObs()
        {
            return observer;
        }

        public void Notify(Pos pos, Piece p)
        {
            observer.Publish(pos, p);
        }

        override public void HighlightValidMoves(Piece p)
        {
            foreach (Pos pos in p.ValidMoves)
            {
                Image i = p.getImageClone();
                i.Opacity = .75;
                ((Button)grid.FindName("Button" + pos.Row.ToString() + pos.Column.ToString())).Content = i;

            }
        }

        override public void ResetHighlights(Piece p)
        {
            foreach (Pos pos in p.ValidMoves)
            {
                ((Button)grid.FindName("Button" + pos.Row.ToString() + pos.Column.ToString())).Content = new Image { Source = new BitmapImage(new Uri("/CheckerBlank.png", UriKind.Relative)) };
            }
        }

        override public void CheckValidMoves(Piece p) // Started working on this and decided to do it later.
        {
            List<Pos> moves = new List<Pos>();
            if (p.ToString() == "CheckersProject.src.BlackPieceDecorator")
            {
                if (p.Row + 1 < 8 && p.Row + 1 >= 0)
                {

                    if (p.Column + 1 < 8 && p.Column + 1 >= 0)
                    {
                        if (Board[p.Row + 1, p.Column + 1].ToString() != "CheckersProject.src.BlankPiece" && Board[p.Row + 1, p.Column + 1].ToString() != p.ToString())
                        {
                            if (p.Row + 2 < 8 && p.Row + 2 >= 0)
                            {
                                if (p.Column + 2 < 8 && p.Column + 2 >= 0)
                                {
                                    if (Board[p.Row + 2, p.Column + 2].ToString() == "CheckersProject.src.BlankPiece")
                                    {
                                        moves.Add(new Pos(p.Row + 2, p.Column + 2));
                                    }
                                }
                            }
                        }
                        else if (Board[p.Row + 1, p.Column + 1].ToString() == "CheckersProject.src.BlankPiece")
                        {
                            moves.Add(new Pos(p.Row + 1, p.Column + 1));
                        }
                    }
                    if (p.Column - 1 < 8 && p.Column - 1 >= 0)
                    {
                        if (Board[p.Row + 1, p.Column - 1].ToString() != "CheckersProject.src.BlankPiece" && Board[p.Row + 1, p.Column - 1].ToString() != p.ToString())
                        {
                            if (p.Row + 2 < 8 && p.Row + 2 >= 0)
                            {
                                if (p.Column - 2 < 8 && p.Column - 2 >= 0)
                                {
                                    if (Board[p.Row + 2, p.Column - 2].ToString() == "CheckersProject.src.BlankPiece")
                                    {
                                        moves.Add(new Pos(p.Row + 2, p.Column - 2));
                                    }
                                }
                            }
                        }
                        else if (Board[p.Row + 1, p.Column - 1].ToString() == "CheckersProject.src.BlankPiece")
                        {
                            moves.Add(new Pos(p.Row + 1, p.Column - 1));
                        }
                    }
                }
                if (p.GetComponent() != null)
                {
                    if (p.Row - 1 < 8 && p.Row - 1 >= 0)
                    {

                        if (p.Column + 1 < 8 && p.Column + 1 >= 0)
                        {
                            if (Board[p.Row - 1, p.Column + 1].ToString() != "CheckersProject.src.BlankPiece" && Board[p.Row - 1, p.Column + 1].ToString() != p.ToString())
                            {
                                if (p.Row - 2 < 8 && p.Row - 2 >= 0)
                                {
                                    if (p.Column + 2 < 8 && p.Column + 2 >= 0)
                                    {
                                        if (Board[p.Row - 2, p.Column + 2].ToString() == "CheckersProject.src.BlankPiece")
                                        {
                                            moves.Add(new Pos(p.Row - 2, p.Column + 2));
                                        }
                                    }
                                }
                            }
                            else if (Board[p.Row - 1, p.Column + 1].ToString() == "CheckersProject.src.BlankPiece")
                            {
                                moves.Add(new Pos(p.Row - 1, p.Column + 1));
                            }
                        }
                        if (p.Column - 1 < 8 && p.Column - 1 >= 0)
                        {
                            if (Board[p.Row - 1, p.Column - 1].ToString() != "CheckersProject.src.BlankPiece" && Board[p.Row - 1, p.Column - 1].ToString() != p.ToString())
                            {
                                if (p.Row - 2 < 8 && p.Row - 2 >= 0)
                                {
                                    if (p.Column - 2 < 8 && p.Column - 2 >= 0)
                                    {
                                        if (Board[p.Row - 2, p.Column - 2].ToString() == "CheckersProject.src.BlankPiece")
                                        {
                                            moves.Add(new Pos(p.Row - 2, p.Column - 2));
                                        }
                                    }
                                }
                            }
                            else if (Board[p.Row - 1, p.Column - 1].ToString() == "CheckersProject.src.BlankPiece")
                            {
                                moves.Add(new Pos(p.Row - 1, p.Column - 1));
                            }
                        }
                    }
                }
            }
            else if (p.ToString() == "CheckersProject.src.RedPieceDecorator")
            {
                if (p.Row - 1 < 8 && p.Row - 1 >= 0)
                {
                    if (p.Column + 1 < 8 && p.Column + 1 >= 0)
                    {
                        if (Board[p.Row - 1, p.Column + 1].ToString() != "CheckersProject.src.BlankPiece" && Board[p.Row - 1, p.Column + 1].ToString() != p.ToString())
                        {
                            if (p.Row - 2 < 8 && p.Row - 2 >= 0)
                            {
                                if (p.Column + 2 < 8 && p.Column + 2 >= 0)
                                {
                                    if (Board[p.Row - 2, p.Column + 2].ToString() == "CheckersProject.src.BlankPiece")
                                    {
                                        moves.Add(new Pos(p.Row - 2, p.Column + 2));
                                    }
                                }
                            }
                        }
                        else if (Board[p.Row - 1, p.Column + 1].ToString() == "CheckersProject.src.BlankPiece")
                        {
                            moves.Add(new Pos(p.Row - 1, p.Column + 1));
                        }
                    }
                    if (p.Column - 1 < 8 && p.Column - 1 >= 0)
                    {
                        if (Board[p.Row - 1, p.Column - 1].ToString() != "CheckersProject.src.BlankPiece" && Board[p.Row - 1, p.Column - 1].ToString() != p.ToString())
                        {
                            if (p.Row - 2 < 8 && p.Row - 2 >= 0)
                            {
                                if (p.Column - 2 < 8 && p.Column - 2 >= 0)
                                {
                                    if (Board[p.Row - 2, p.Column - 2].ToString() == "CheckersProject.src.BlankPiece")
                                    {
                                        moves.Add(new Pos(p.Row - 2, p.Column - 2));
                                    }
                                }
                            }
                        }
                        else if ((Board[p.Row - 1, p.Column - 1].ToString() == "CheckersProject.src.BlankPiece"))
                        {
                            moves.Add(new Pos(p.Row - 1, p.Column - 1));
                        }
                    }
                }
                if (p.GetComponent() != null)
                {
                    if (p.Column + 1 < 8 && p.Column + 1 >= 0)
                    {
                        if (Board[p.Row + 1, p.Column + 1].ToString() != "CheckersProject.src.BlankPiece" && Board[p.Row + 1, p.Column + 1].ToString() != p.ToString())
                        {
                            if (p.Row + 2 < 8 && p.Row + 2 >= 0)
                            {
                                if (p.Column + 2 < 8 && p.Column + 2 >= 0)
                                {
                                    if (Board[p.Row + 2, p.Column + 2].ToString() == "CheckersProject.src.BlankPiece")
                                    {
                                        moves.Add(new Pos(p.Row + 2, p.Column + 2));
                                    }
                                }
                            }
                        }
                        else if (Board[p.Row + 1, p.Column + 1].ToString() == "CheckersProject.src.BlankPiece")
                        {
                            moves.Add(new Pos(p.Row + 1, p.Column + 1));
                        }
                    }
                    if (p.Column - 1 < 8 && p.Column - 1 >= 0)
                    {
                        if (Board[p.Row + 1, p.Column - 1].ToString() != "CheckersProject.src.BlankPiece" && Board[p.Row + 1, p.Column - 1].ToString() != p.ToString())
                        {
                            if (p.Row + 2 < 8 && p.Row + 2 >= 0)
                            {
                                if (p.Column - 2 < 8 && p.Column - 2 >= 0)
                                {
                                    if (Board[p.Row + 2, p.Column - 2].ToString() == "CheckersProject.src.BlankPiece")
                                    {
                                        moves.Add(new Pos(p.Row + 2, p.Column - 2));
                                    }
                                }
                            }
                        }
                        else if (Board[p.Row + 1, p.Column - 1].ToString() == "CheckersProject.src.BlankPiece")
                        {
                            moves.Add(new Pos(p.Row + 1, p.Column - 1));
                        }
                    }
                }
            }
            p.SetValidMoves(moves);
        }
        override public bool Move(Pos pos, Piece p, bool IsIncomingNetworkMove)
        {

            bool moveFound = false;
            if (p.ValidMoves == null)
            {
                CheckValidMoves(p);
            }
            else
            {
                ResetHighlights(p);
            }
            /*if (p.ToString() != "CheckersProject.src.RedPieceDecorator")
            {

                return false;
            }*/
            /* For now, this is just a really complicated swap afterwards it updates both of the images*/
            foreach (Pos x in p.ValidMoves)
            {
                if (x.Row == pos.Row && x.Column == pos.Column)
                {
                    moveFound = true;
                    break;
                }
            }
            if (p != null && Board[pos.Row, pos.Column] != null && moveFound == true)
            {
                if (Math.Abs(pos.Row - p.Row) > 1 && Math.Abs(pos.Column - p.Column) > 1)
                {
                    if (Board[(p.Row + pos.Row) / 2, (p.Column + pos.Column) / 2].ToString() == "CheckersProject.src.BlackPieceDecorator")
                    {
                        Window.Player_2_Amount.Text = (Int32.Parse(Window.Player_2_Amount.Text) - 1).ToString();
                    }
                    else
                    {
                        Window.Player_1_Amount.Text = (Int32.Parse(Window.Player_1_Amount.Text) - 1).ToString();
                    }
                    if(IsIncomingNetworkMove == false)
                    {
                        Notify(pos, p);
                    }
                    else if (IsIncomingNetworkMove == true)
                    {
                        this.State = (GameState)(-((int)this.State));
                    }
                    Board[(p.Row + pos.Row) / 2, (p.Column + pos.Column) / 2] = new BlankPiece(null, new Pos((p.Row + pos.Row) / 2, (p.Column + pos.Column) / 2));
                    Board[(p.Row + pos.Row) / 2, (p.Column + pos.Column) / 2].updateImage(Window);

                    Piece temp = Board[pos.Row, pos.Column];
                    Board[pos.Row, pos.Column] = p;
                    Board[p.Row, p.Column] = temp;
                    Board[p.Row, p.Column].Row = p.Row;
                    Board[p.Row, p.Column].Column = p.Column;
                    temp = Board[p.Row, p.Column];
                    p.Row = pos.Row;
                    p.Column = pos.Column;


                    temp.updateImage(Window);
                    p.updateImage(Window);
                    return true;
                }
                else
                {
                    if (IsIncomingNetworkMove == false)
                    {
                        Notify(pos, p);
                    }
                    else if (IsIncomingNetworkMove == true)
                    {
                        this.State = (GameState)(-((int)this.State));
                    }
                    Piece temp = Board[pos.Row, pos.Column];
                    Board[pos.Row, pos.Column] = p;
                    Board[p.Row, p.Column] = temp;
                    Board[p.Row, p.Column].Row = p.Row;
                    Board[p.Row, p.Column].Column = p.Column;
                    temp = Board[p.Row, p.Column];
                    p.Row = pos.Row;
                    p.Column = pos.Column;

                    temp.updateImage(Window);
                    p.updateImage(Window);
                    return true;
                }
            }
            return false;

        }

        override public void SetPiece(Pos pos, Piece p)
        {
            Board[pos.Row, pos.Column] = p;
            p.updateImage(Window);
            /* updateImage just takes the Board xaml, finds the button linked to the piece,
             * and changes the button's content to the correct image*/
        }

        override public Piece GetPiece(Pos pos)
        {
            return Board[pos.Row, pos.Column];
        }

    }
}
