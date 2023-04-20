using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CheckersProject.src
{
    public enum GameType
    {
        LAN,
        MultiplayerHost,
        MultiplayerJoin,
    }

    public enum GameState
    {
        unstarted,
        redTurn = -1,
        blackTurn = 1,
        redWin,
        blackWin,
        redForfeit,
        blackForfeit,
    }
    internal abstract class Player
    {
        private Piece[,] board = new Piece[8, 8];
        private GameState state;
        readonly Board B;

        public GameState State { get { return state; } set { state = value; } }
        public Grid grid { get { return B.grid; } }
        public Board Window { get { return B; } }
        public Piece[,] Board { get { return board; } } 
        public Player(Board b)
        {
            B = b;
        }

        abstract public void HighlightValidMoves(Piece p);
        abstract public void ResetHighlights(Piece p);
        abstract public void CheckValidMoves(Piece p);

        abstract public bool Move(Pos pos, Piece p, bool IsIncomingNetworkMove, bool IsDispatched);

        abstract public void SetPiece(Pos pos, Piece p);

        abstract public Piece GetPiece(Pos pos);
        

    }
}
