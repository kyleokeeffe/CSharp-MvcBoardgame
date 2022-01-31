using System;
using System.Collections.Generic;
using System.Text;
using mvctrial2.Models;
using mvctrial2.Services;
using static mvctrial2.Services.ControllerService;

namespace mvctrial2.Controllers
{
    public sealed class PieceController:ControllerService
    {
        private static PieceController _Instance;
       // private GameController _GameCon;
       // private BoardController _BoardCon;
       // private ControllerService _ContServ;


       // public GameController GameCon { get { return this._GameCon; } set { this._GameCon = value; } }
       // public BoardController BoardCon { get { return this._BoardCon; } set { this._BoardCon = value; } }
      //  public ControllerService ContServ { get { return this._ContServ; } set { this._ContServ = value; } }

        private PieceController()
        {
        //    this.GameCon = this.ContServ.GameCon;
         //   this.BoardCon = this.ContServ.BoardCon;
        }

        public static PieceController GetInstance()
        {
            if(_Instance == null)
            {
                _Instance = new PieceController();
            }
            return _Instance;
        }



        public bool Move(Piece piece,int newX, int newY)
        {
            bool success = false;
            try
            {

                piece.Location = BoardCon.GetSquare(newX, newY);
                success = true;
            }
            catch (Exception e)
            {

            }

            //update view
            return success;
        }

        public bool Move(Piece piece,Square newSquare)
        {
            bool success = false;
            return success;
        }


        public List<Square> GetLegalMoves(Piece piece)
        {
            List<Square> legalMoves = new List<Square>();

            Square checkSquare = BoardCon.GetSquare(piece.Location.X + 1, piece.Location.Y + 1);
            if (checkSquare.Piece != null)
            {
                checkSquare = BoardCon.GetSquare(piece.Location.X + 2, piece.Location.Y + 2);
                if (checkSquare.Piece != null)
                    checkSquare = null;
            }
            legalMoves.Add(checkSquare);
            return legalMoves;
            //from location get two squares, 
            //check location for piece 
            //if theres a piece, check next square 
            // if no piece, return square add to potential move array

        }

        public string PrintLocation(Piece piece)
        {
            return $"({piece.Location.X},{piece.Location.Y})";
        }
    }
}
