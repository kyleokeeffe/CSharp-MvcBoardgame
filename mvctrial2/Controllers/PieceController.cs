using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using mvctrial2.Models;
using mvctrial2.Services;


namespace mvctrial2.Controllers
{
    public sealed class PieceController
    {
        
        private PieceController()
        {
     
        }

         public static PieceController Instance { get { return Nested.instance; } }

        private class Nested
        {
            static Nested() { }
            internal static readonly PieceController instance = CreatePC();
        }
        public void Serve() { }
        public static PieceController CreatePC()
        {
            PieceController pc = new PieceController();
            InitializeService();
            //pc.AttachService();
            return pc;
        }

        public static void InitializeService()
        {
            ServiceProvider serviceProvider = ((App)Application.Current).GetService();
            var serviceOperation = serviceProvider.GetService<ISingletonOperation>();
            serviceOperation.BuildGameCon();
        }

        /*public void AttachService()
         {
             cs = ControllerService.Instance;
             cs.PieceCon = this;
         }*/
        public BoardController GetBoardService()
        {
            ServiceProvider serviceProvider = ((App)Application.Current).GetService();
            var serviceOperation = serviceProvider.GetService<ISingletonOperation>();
            BoardController BoardCon = serviceOperation.BoardCon;
            return BoardCon;
        }

        public bool Move(Piece piece,int newX, int newY)
        {
            bool success = false;
            try
            {

                piece.Location = GetBoardService().GetSquare(newX, newY);
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


           
            Square checkSquare = GetBoardService().GetSquare(piece.Location.X + 1, piece.Location.Y + 1);
            
            if (checkSquare.Piece != null)
            {
                /* checkSquare = cs.BoardCon.GetSquare(piece.Location.X + 2, piece.Location.Y + 2);
                 if (checkSquare.Piece != null)
                     checkSquare = null;*/
                legalMoves.Add(checkSquare);
            }
            
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
