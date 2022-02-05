using mvctrial2.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace mvctrial2.Services
{
    public class DefaultOperation : ISingletonOperation
    {
        /*public void DoThing()
        {
            MessageBox.Show("default thing");
        }*/
        public GameController GameCon { get { return GameController.Instance; } set { value=GameController.Instance; } }
        public BoardController BoardCon { get { return BoardController.Instance; } set { value = BoardController.Instance; } }
        public PieceController PieceCon { get { return PieceController.Instance; } set { value = PieceController.Instance; } }

        public void BuildBoardCon()
        {
            this.BoardCon = BoardController.Instance;
        }

        public void BuildGameCon()
        {
            this.GameCon = GameController.Instance;
        }

        public void BuildPieceCon()
        {
            this.PieceCon = PieceController.Instance;
        }
    }

}
