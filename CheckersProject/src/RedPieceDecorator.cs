﻿/**
 * @file RedPieceDecorator.cs
 * @authors Connor Walsh, Daniel Cunningham
 * @date 2023-4-19
 * @brief cs file for the RedPieceDecorator
 * 
 * This file contains the logic for the decorator for a red piece on the board. 
 * It contains logic for performing tasks such as king promotion. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CheckersProject.src
{
    internal class RedPieceDecorator : ABSPieceDecorator
    {

        public RedPieceDecorator(Piece c, Pos pos) : base(c) {
            Row = pos.Row;
            Column = pos.Column;
            BitmapImage source = new BitmapImage(new Uri("/CheckerRedTransparent.png", UriKind.Relative));
            i.Source = source;
        }
        
        public override void updateImage(Board b)
        {
            if (Component == null)
            {
                Button button = (Button)b.grid.FindName("Button" + Row.ToString() + Column.ToString());
                button.Content = i;
            }
            else
            {
                UpdateComponent();
                Component.updateImage(b);
            }
        }

        public override void UpdateComponent()
        {
            Component.Row = Row;
            Component.Column = Column;
        }

        public override Piece GetComponent()
        {
            return Component;
        }

        public override Image getImage()
        {
            return i;
        }

        public override List<Pos> CheckValidMoves(Piece[,] board)
        {
            if (Component != null)
            {
                return Component.CheckValidMoves(board);
            }
            List<Pos> moves = new List<Pos>();
            Pos[] positions = new Pos[2];
            positions[0] = CheckValidSpot(board, Row - 1, Column + 1, Direction.Up, Direction.Right);
            positions[1] = CheckValidSpot(board, Row - 1, Column - 1, Direction.Up, Direction.Left);
            foreach (Pos p in positions)
            {
                if (p != null)
                {
                    moves.Add(p);
                }
            }
            return moves;
        }

        public override Pos CheckValidSpot(Piece[,] board, int r, int c, Direction Vertical, Direction Horizontal)
        {
            if (r > 7 || r < 0 || c > 7 || c < 0)
            {
                return null;
            }
            if (board[r, c].ToString() != "CheckersProject.src.BlankPiece" && board[r, c].ToString() != this.ToString())
            {
                if (r + ((int)Vertical) > 7 || r + ((int)Vertical) < 0 || c + ((int)Horizontal) > 7 || c + ((int)Horizontal) < 0)
                {
                    return null;
                }

                else if (board[r + ((int)Vertical), c + ((int)Horizontal)].ToString() == "CheckersProject.src.BlankPiece")
                {
                    return new Pos(r + ((int)Vertical), c + ((int)Horizontal));
                }

            }
            else if (board[r, c].ToString() == "CheckersProject.src.BlankPiece")
            {
                return new Pos(r, c);
            }
            return null;
        }

        public override void SetValidMoves(List<Pos> validMoves)
        {
            ValidMoves = validMoves;
        }

        public override Image getImageClone()
        {
            Image image2 = new Image();
            image2.Source = i.Source;
            return image2;
        }

        public override bool CheckPromotion()
        {
            if (Component == null)
            {
                if (Row == 0)
                {
                    Component = new KingDecorator(null, new Pos(Row, Column), this.ToString());
                    return true;

                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
