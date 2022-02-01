using System;
using System.Collections.Generic;
using System.Text;

namespace mvctrial2.Models
{
    public class Board
    {
        private List<Square> _Squares;
        public List<Square> Squares { get { return this._Squares; } set { this._Squares=value; } }

        public Board()
        {
            //PopulateBoard();
            this.Squares = new List<Square>();
        }


        public void PopulateBoard()
         {
            this.Squares = new List<Square>();
            for(int row = 0; row < 10; row++)
            {
                for(int col = 0; col < 10; col++)
                {
                    Square thisSquare = new Square(row,col);
   


                    this.Squares.Add(thisSquare);
                }
            }
        }


        public string PrintBoard()
        {
            string printBoard="";
            
            foreach(Square square in this.Squares)
            {
                printBoard+=$"({square.X},{square.Y})\n";
            }
            return printBoard;
            
        }

        //public Square GetSquare(int x, int y)
        //{
        //    Square thisSquare;
        //    try
        //    {
        //        thisSquare = this.Squares.Find(item => { return item.X == x && item.Y == y; });
        //    }
        //    catch (Exception e)
        //    {
        //        //throw custom exception of square not found
        //        Console.WriteLine("Sorry not found");
        //        thisSquare = null;
        //    }
        //    return thisSquare;
        //}

     
  
    }
}
