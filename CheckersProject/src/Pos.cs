/**
 * @file BlackPieceDecorator.cs
 * @authors Connor Walsh, Daniel Cunningham
 * @date 2023-4-19
 * @brief cs file for the Pos class
 * 
 * This file contains the logic for the Position class which is 
 * used to move the checker pieces on the board. 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersProject.src
{
    internal class Pos
    {
        private int row, column;

        public Pos(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
        public int Row
        {
            get { return row; }
            set { row = value;}
        }

        public int Column
        {
            get { return column; }
            set { column = value; }
        }
    }
}
