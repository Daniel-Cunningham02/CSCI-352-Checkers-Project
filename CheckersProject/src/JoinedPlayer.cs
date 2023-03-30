using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Data;
using static CheckersProject.src.CmdManager;
using System.Windows;

namespace CheckersProject.src
{
    internal class JoinedPlayer : Player
    {
        TcpClient client;
        StreamWriter sw;
        StreamReader sr;
        Thread Read;
        Thread Write;
        CmdManager cm;
        int Port;
        string ip;
        public JoinedPlayer(Board b, string IP) : base(b)
        {
            char[] split =
            {
                ':'
            };
            cm = new CmdManager();
            string[] address = IP.Split(split, 2);
            client = new TcpClient();
            Port = Int32.Parse(address[1]);
            ip = address[0];
            
        }

        public void Connect()
        {
            client.Connect(ip, Port);
            Read = new Thread(new ThreadStart(this.Listen));
            sr = new StreamReader(client.GetStream(), Encoding.ASCII);
            sw = new StreamWriter(client.GetStream(), Encoding.ASCII);
            sw.WriteLine("Connect");
            sw.Flush();
            Read.Start();
           
        }

        private void Listen()
        {
            while(client.Connected)
            {
                string inData = sr.ReadLine();
                CmdType type = cm.RegisterCommand(ref inData);
                if (type == CmdType.Move)
                {
                    int rowStart = Int32.Parse(inData.Substring(0, inData.IndexOf(" ")));// Takes RowStart
                    inData = inData.Substring(inData.IndexOf(" ") + 1); // Trims the string down to "{colStart} {rowEnd} {colEnd}"
                    int colStart = Int32.Parse(inData.Substring(0, inData.IndexOf(" "))); // Takes colStart
                    inData = inData.Substring(inData.IndexOf(" ") + 1); // Trims the string down to {rowEnd} {colEnd}
                    int rowEnd = Int32.Parse(inData.Substring(0, inData.IndexOf(" ")));// Takes RowStart
                    inData = inData.Substring(inData.IndexOf(" ") + 1); // Trims the string down to "{colStart} {rowEnd} {colEnd}"
                    int colEnd = Int32.Parse(inData); // Takes colStart
                    Pos pos = new Pos(rowEnd, colEnd);
                    Piece piece = Board[rowStart, colStart];
                    Move(pos, piece, true);
                    
                }
                else if (type == CmdType.Forfeit)
                {
                    client.Close();
                    this.Close();
                }
                else if (type == CmdType.Leave)
                {
                    client.Close();
                    this.Close();
                }
            }
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
                grid.Dispatcher.Invoke(() =>
                {
                    ((Button)grid.FindName("Button" + pos.Row.ToString() + pos.Column.ToString())).Content = new Image
                    {
                        Source = new BitmapImage(new Uri("/CheckerBlank.png", UriKind.Relative))
                    };
                });
                
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
                    if (IsIncomingNetworkMove == false)
                    {
                        SendData(pos, p);
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
                        SendData(pos, p);
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

        public void Close()
        {
            sw.Close();
            sr.Close();
            Read.Join();
        }

        public void SendData(Pos pos, Piece p)
        {
            sw.WriteLine("Move " + p.Row + " " + p.Column + " " + pos.Row + " " + pos.Column);
            sw.WriteLine("GameStateSwap");
            sw.Flush();
        }
    }
}
