/**
 * @file ABSPieceDecorator.cs
 * @authors Connor Walsh, Daniel Cunningham
 * @date 2023-4-19
 * @brief cs file for the abstract Decorator
 * 
 * This file contains the logic abstract Decorator that the other decorator 
 * classes inherit from. 
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersProject.src
{
    internal abstract class ABSPieceDecorator : Piece
    {
        private Piece component;


        protected Piece Component {
            get { return component; }
            set { component = value; }
        }
        public ABSPieceDecorator(Piece c)
        {
            this.component = c;
        }

    }
}
