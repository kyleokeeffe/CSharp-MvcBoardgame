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

        //public void CreatePieces()
        //{
  
        //    Brush thisCol;
      
        //    int[] startingRows = { 0, 1, 8, 9 };
        //    for (int i = 0; i < 23; i++)
        //    {
        //        if(i <= 11)
        //            thisCol = Brushes.Black;
        //        else
        //            thisCol = Brushes.White;

        //        foreach (int x in startingRows)
        //        {

                
                
        //            for(int y = 0;y<10;y++)
        //            {



        //                Piece thisPiece = new Piece(thisCol, x, y);
        //                this.Pieces.Add(thisPiece);

        //                this.Board.GetSquare(thisPiece.X, thisPiece.Y).Piece = thisPiece;


        //            }

                
        //        }
                

              


           


        //    }
        //}


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
