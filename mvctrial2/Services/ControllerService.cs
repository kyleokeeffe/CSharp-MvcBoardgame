using System;
using System.Collections.Generic;
using System.Text;
using mvctrial2.Controllers;

namespace mvctrial2.Services
{
    public static class ControllerService
    {
     
        public static readonly GameController GameCon;
        public static readonly PieceController PieceCon;
        public static readonly BoardController BoardCon;

       // public GameController GameCon { get { return this._GameCon; } set { this._GameCon = value; } }
       // public PieceController PieceCon { get { return this._PieceCon; } set { this._PieceCon = value; } }
      // public BoardController BoardCon { get { return this._BoardCon; } set { this._BoardCon = value; } }

        static ControllerService()
        {
            GameCon = GameController.GetInstance();
            BoardCon = BoardController.GetInstance();
            PieceCon = PieceController.GetInstance();
         
        }
    }
}
