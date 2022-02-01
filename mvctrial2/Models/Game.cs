using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace mvctrial2.Models
{
    public class Game
    {
        private List<Piece> _Pieces;
        private Board _Board;

        public Board Board { get {return this._Board; } set { this._Board = value; } }
        public List<Piece> Pieces { get { return this._Pieces; } set { this._Pieces = value; } }

        public Game()
        {
            this.Pieces = new List<Piece>();
            this.Board = new Board(); 
        }

        


        public string PrintPieces()
        {
            string printBoard = "";

            foreach (Piece piece in this.Pieces)
            {
                printBoard += $"{piece.Color}:({piece.X},{piece.Y})\n";
            }
            return printBoard;

        
    }

      

    }
}
