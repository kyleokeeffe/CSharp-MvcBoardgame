using System;
using System.Collections.Generic;
using System.Text;

namespace mvctrial2.Models
{
    public class Square
    {
        private int _X;
        private int _Y;
        private Piece _Piece;
        private bool _PiecePresent;

        public int X { get { return this._X; } set { this._X = value; } }
        public int Y { get { return this._Y; } set { this._Y = value; } }
        public Piece Piece { get {return this._Piece; } set {this._Piece=value; } }
        public bool PiecePresent { get { return this._PiecePresent; } set { this._PiecePresent = value; } }

        public Square(int x, int y)
        {
            this._X = x;
            this._Y = y;
            this.Piece = null;
            this.PiecePresent = false;
        }

        public override string ToString()
        {
            return $"{this.GetType()}: ({this.X}, {this.Y}) {this.Piece.ToString()}";
           // return $"{this.GetType()}: ({this.X}, {this.Y}), {this.Piece.ToString()}";
        }


    }
}
