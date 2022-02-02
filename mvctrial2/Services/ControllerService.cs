using System;
using System.Collections.Generic;
using System.Text;
using mvctrial2.Controllers;

namespace mvctrial2.Services
{
    public sealed class ControllerService:IControllerService
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

        private List<IControllerService> _ServiceComponents;
       // private GameController _GameCon;
        //private PieceController _PieceCon;
        //private BoardController _BoardCon;
        public List<IControllerService> ServiceComponents { get { return this._ServiceComponents; } set { this._ServiceComponents = value; } }
        //public PieceController PieceCon {get{return _PieceCon;} set{this._PieceCon=value;}}
        //public GameController GameCon {get{return this._GameCon;} set{this._GameCon = value; }}
        //public BoardController BoardCon {get{return this._BoardCon;} set{this._BoardCon = value; }}
        

  

        public void InitializeService()
        {
            this.ServiceComponents = new List<IControllerService>();

            AddComponent(BoardController.Instance);
            AddComponent(PieceController.Instance);
            AddComponent(GameController.Instance);
            //BoardCon = BoardController.Instance;


           // PieceCon =  PieceController.Instance;
           // GameCon = GameController.Instance;
      
        }

        public void AddComponent(IControllerService component)
        {
            this.ServiceComponents.Add(component);
        }
        public void RemoveComponent(IControllerService component)
        {
            this.ServiceComponents.Remove(component);
        }


    
    }
}
