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
            gc.InitiateGame();
            return gc;
        }
        private void SayHello()
        {
            MessageBox.Show("hello");
        }

        private ControllerService cs;
        //private static GameController _Instance;
        //private ControllerService cs = ControllerService.Instance;
        //private BoardController _BoardCon;
        //private GameController GameCon = GameController.GetInstance();
        //private BoardController BoardCon = BoardController.GetInstance();
       // private PieceController PieceCon = PieceController.GetInstance();
        private Game _Game;
        private Dictionary<Square, Rectangle>_ViewMap;
        //private ControllerService _ContServ;

        public Game Game { get {return this._Game; } set {this._Game=value; } }
        public Dictionary<Square, Rectangle> ViewMap { get { return this._ViewMap; } set { this._ViewMap = value; } }
        //public BoardController BoardCon { get { return this._BoardCon; } set { this._BoardCon = value; } }
        //public ControllerService ContServ { get { return this._ContServ; } set { this._ContServ = value; } }

        /* private GameController()
         {
             //this.BoardCon = ControllerService.BoardCon;
             this.Game = new Game();
             this.ViewMap = new Dictionary<Square, Rectangle>();

             CreatePieces();
         }*/
        /* public static GameController GetInstance(){
             if (_Instance ==null){

                 //ControllerService _Instance = ControllerService.GetServiceInstance();
                 //_Instance = (GameController)_Instance;
                 _Instance = new GameController();
             }
             return _Instance;
         }*/

        public void AttachService()
        {
            cs = ControllerService.Instance;
            cs.GameCon = this;
        }
        public void InitiateGame()
        {

            this.Game = new Game();
            this.ViewMap = new Dictionary<Square, Rectangle>();

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
            //using map and
            //add node to grid

        }
        /*public Square GetSquare(int x, int y)
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
        }*/


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
