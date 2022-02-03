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
        public GameController GameCon { get ; set ; }
        public BoardController BoardCon { get ;set; }
        public PieceController PieceCon { get ; set; }

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
