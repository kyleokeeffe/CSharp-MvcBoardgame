using System;
using System.Collections.Generic;
using System.Text;
using mvctrial2.Controllers;

namespace mvctrial2.Services
{
    public sealed class ControllerService
    {
        private ControllerService()
        {
  

        }

        public static ControllerService Instance { get { return Nested.instance; } }

        private class Nested
        {
            static Nested() { }
            internal static readonly ControllerService instance = new ControllerService();
        }
        private GameController _GameCon;
        private PieceController _PieceCon;
        private BoardController _BoardCon;
        public PieceController PieceCon {get{return _PieceCon;} set{this._PieceCon=value;}}
        public GameController GameCon {get{return this._GameCon;} set{this._GameCon = value; }}
        public BoardController BoardCon {get{return this._BoardCon;} set{this._BoardCon = value; }}
        

  

        public void InitializeService()
        {
            BoardCon = BoardController.Instance;
            
         
            PieceCon = PieceController.Instance;
            GameCon = GameController.Instance;
      
        }


    
    }
}
