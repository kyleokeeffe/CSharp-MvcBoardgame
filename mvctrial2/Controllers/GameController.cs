using mvctrial2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace mvctrial2.Controllers
{
    public class GameController
    {
        private Game _Game;
        private Dictionary<Square, Rectangle>_ViewMap;
        public Game Game { get {return this._Game; } set {this._Game=value; } }
        public Dictionary<Square, Rectangle> ViewMap { get { return this._ViewMap; } set { this._ViewMap = value; } }


        public GameController()
        {
            this.Game = new Game();
            this.ViewMap = new Dictionary<Square, Rectangle>();
            CreatePieces();
        }

        private void CreatePieces()
        {
            Brush thisCol;

            int[] startingRows = { 0, 1, 8, 9 };
            int counter = 0;
               

                foreach (int x in startingRows)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        if (counter <= 11)
                            thisCol = Brushes.Black;
                        else
                            thisCol = Brushes.White;
                        Piece thisPiece = new Piece(thisCol, x, y);
                        thisPiece.Location = GetSquare(x, y);
                        this.Game.Pieces.Add(thisPiece);
                        counter++;
                    }
                }
            }
        
        public void PrintPieces()
        {
            //using map and
            //add node to grid
        }
        public Square GetSquare(int x, int y)
        {
            Square thisSquare;
            try
            {
                thisSquare = this.Game.Board.Squares.Find(item => { return item.X == x && item.Y == y; });
            }
            catch (Exception e)
            {
                //throw custom exception of square not found
                Console.WriteLine("Sorry not found");
                thisSquare = null;
            }
            return thisSquare;
        }

    }
}
