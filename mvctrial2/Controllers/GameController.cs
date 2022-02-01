using mvctrial2.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;
using mvctrial2.Services;
using static mvctrial2.Services.ControllerService;
using System.Windows;

namespace mvctrial2.Controllers
{
    public sealed class GameController
    {
       
        private GameController() {
         
          
            
            
        }
        public static GameController Instance { get { return Nested.instance; }  }

        private class Nested
        {
            static Nested() { }
            internal static readonly GameController instance = CreateGC();
        }
        public static GameController CreateGC()
        {
            GameController gc = new GameController();
            gc.SayHello();
            gc.AttachService();
           // gc.InitiateGame();
            return gc;
        }
        private void SayHello()
        {
            MessageBox.Show("hello");
        }

        private ControllerService cs;
        
        private Game _Game;
        private Dictionary<Square, Rectangle>_ViewMap;


        public Game Game { get {return this._Game; } set {this._Game=value; } }
        public Dictionary<Square, Rectangle> ViewMap { get { return this._ViewMap; } set { this._ViewMap = value; } }


        public void AttachService()
        {
            cs = ControllerService.Instance;
            cs.GameCon = this;
        }
        public void InitiateGame()
        {

            this.ViewMap = new Dictionary<Square, Rectangle>();
            this.Game = new Game();
            cs.BoardCon.BuildBoard();

            CreatePieces();
        }


        public void CreatePieces()
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
                        thisPiece.Location = cs.BoardCon.GetSquare(x, y);
                        this.Game.Pieces.Add(thisPiece);
                        counter++;
                    }
                }
            }
        
        public void PrintPieces()
        {
            foreach(Piece piece in this.Game.Pieces)
            {
                cs.BoardCon.AddTextBlock(piece.Location);
            }
            //using map
            //add node to grid

        }
   


        public Piece CheckSquareForPiece(Square square)
        {
            Piece piece;



            if (square.Piece != null)
                piece = square.Piece;
            else
                piece = null;
            return piece;
        }
    }
}
