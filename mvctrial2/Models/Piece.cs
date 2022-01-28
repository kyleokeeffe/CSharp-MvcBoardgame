using mvctrial2.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvctrial2.Models
{
    public class Piece
    {
        private System.Windows.Media.Brush _Color;
        private int _X;
        private int _Y;
        private Square _Location;
        private static GameController GameCon = new GameController();

        public int X { get {return this._X; } set {this._X = value; } }
        public int Y { get {return this._Y; } set {this._Y = value; } }
        public System.Windows.Media.Brush Color { get { return this._Color; } set { this._Color = value; } }
        public Square Location { get {return this._Location; } set {this._Location=value;this._Location.Piece = this; } }
        
        public Piece(System.Windows.Media.Brush color, int x, int y)
        {
            this._Color = color;
            this.X = x;
            this.Y = y;
        }
    

        public bool Move(int newX, int newY)
        {
            bool success = false;
            try
            {

                this.Location = GameCon.GetSquare(newX, newY);
                success = true;
            }catch(Exception e)
            {
                
            }

            //update view
            return success;
        }

        public bool Move(Square newSquare)
        {
            bool success = false;
            return success;
        }


        public List<Square> GetLegalMoves()
        {
            List<Square> legalMoves = new List<Square>();

            Square checkSquare = GameCon.GetSquare(this.Location.X+1, this.Location.Y + 1);
            if (checkSquare.Piece != null)
            {
                checkSquare = GameCon.GetSquare(this.Location.X + 2, this.Location.Y + 2);
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

        public string PrintLocation()
        {
            return $"({this.Location.X},{this.Location.Y})";
        }

    }
}
