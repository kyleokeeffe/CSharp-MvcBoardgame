using mvctrial2.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvctrial2.Services
{
    public interface IOperation
    {

        GameController GameCon { get; set; }
        BoardController BoardCon { get; set; }
        PieceController PieceCon { get; set; }

        void BuildGameCon();
        void BuildBoardCon();
        void BuildPieceCon();
    }
}
