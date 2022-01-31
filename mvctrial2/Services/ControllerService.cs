using System;
using System.Collections.Generic;
using System.Text;
using mvctrial2.Controllers;

namespace mvctrial2.Services
{
    public class ControllerService
    {
        private static ControllerService _Instance;
        private GameController _GameCon;
        private PieceController _PieceCon;
        private BoardController _BoardCon;
        public PieceController PieceCon {get{return this._PieceCon;} set{this._PieceCon=value;}}
        public GameController GameCon {get{return this._GameCon;} set{this._GameCon = value; }}
        public BoardController BoardCon {get{return this._BoardCon;} set{this._BoardCon = value; }}


        // public GameController GameCon { get { return this._GameCon; } set { this._GameCon = value; } }
        // public PieceController PieceCon { get { return this._PieceCon; } set { this._PieceCon = value; } }
        // public BoardController BoardCon { get { return this._BoardCon; } set { this._BoardCon = value; } }

        private ControllerService()
        {
            GameCon = GameController.GetInstance();
            BoardCon = BoardController.GetInstance();
            PieceCon = PieceController.GetInstance();

        }
        public static ControllerService GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new ControllerService();
            }
            return _Instance;
        }
    
    }
}
