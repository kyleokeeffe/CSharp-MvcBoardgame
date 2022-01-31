using System;
using System.Collections.Generic;
using System.Text;
using mvctrial2.Models;
using System.Windows.Shapes;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using mvctrial2.Services;
using static mvctrial2.Services.ControllerService;


namespace mvctrial2.Controllers
{
    public sealed class BoardController
    {
       private static BoardController _Instance;

        //private static readonly BoardController instance = new BoardController();


       // private ControllerService _ContServ;
       // private GameController _GameCon;
      //  private PieceController _PieceCon;
        private Grid _BoardGrid;

      //  public GameController GameCon { get { return this._GameCon; } set { this._GameCon = value; } }
       // public PieceController PieceCon { get { return this._PieceCon; } set { this._PieceCon = value; } }
        
      //  public ControllerService ContServ { get { return this._ContServ; } set { this._ContServ = value; } }
        
       /* private BoardController() {
            this.BoardGrid = ((MainWindow)Application.Current.MainWindow).boardGrid;
        }*/
        //public static BoardController Instance { get { return instance; } }
        
        public Grid BoardGrid { get { return this._BoardGrid; } set { this._BoardGrid = value; } }

    

        private BoardController()
        {
           // this.GameCon = ContServ.GameCon;
           // this.PieceCon = ContServ.PieceCon;
            this.BoardGrid = ((MainWindow)Application.Current.MainWindow).boardGrid;
        }

        public static BoardController GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new BoardController();
            }
            return _Instance;
        }

        public Square GetSquare(Rectangle rect)
        {
            Square associatedSquare = GameCon.ViewMap.FirstOrDefault(keyValuePair => keyValuePair.Value == rect).Key;
            return associatedSquare;
        }

        public Square GetSquare(int x, int y)
        {
            Rectangle rect = GetRect(x, y);


            Square associatedSquare = GameCon.ViewMap.FirstOrDefault(keyValuePair => keyValuePair.Value == rect).Key;

            /*Square thisSquare;
                try
                {
                    thisSquare = this.Game.Board.Squares.Find(item => { return item.X == x && item.Y == y; });
                }
                catch (Exception e)
                {
                    //throw custom exception of square not found
                    Console.WriteLine("Sorry not found");
                    thisSquare = null;
                }*/
            return associatedSquare;
           
        }

        public Rectangle GetRect(int x, int y)
        {
            var query = GameCon.ViewMap.Keys.AsQueryable<Square>().Where<Square>(thing => thing.X == x && thing.Y == y);
            bool keyFound = false;
            Rectangle foundRect = new Rectangle();
            foreach (var key in query)
            {
                keyFound = GameCon.ViewMap.TryGetValue(key, out Rectangle thing);
                if (keyFound == true)
                {
                    foundRect = GameCon.ViewMap[key];
                }
                else
                {
                    foundRect = null;
                    MessageBox.Show("keynot found");
                }
            }
            return foundRect;


        }

        public Rectangle GetRect(Square square)
        {
            var query = GameCon.ViewMap.Keys.AsQueryable<Square>().Where<Square>(thing => thing.X == square.X && thing.Y == square.Y);
            bool keyFound = false;
            Rectangle foundRect = new Rectangle();
            foreach (var key in query)
            {
                keyFound = GameCon.ViewMap.TryGetValue(key, out Rectangle thing);
                if (keyFound == true)
                {
                    foundRect = GameCon.ViewMap[key];
                }
                else
                {
                    foundRect = null;
                    MessageBox.Show("keynot found");
                }
            }
            return foundRect;


        }


        public void BuildBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Rectangle thisRect = new Rectangle();

                    thisRect.SetValue(Grid.RowProperty, i);
                    thisRect.SetValue(Grid.ColumnProperty, j);
                    if (j % 2 == 0)
                    {
                        if (i % 2 == 0)
                            thisRect.Fill = new SolidColorBrush(Colors.LightGray);
                        else
                            thisRect.Fill = new SolidColorBrush(Colors.Gray);
                    }
                    else
                    {
                        if (i % 2 == 0)
                            thisRect.Fill = new SolidColorBrush(Colors.Gray);
                        else
                            thisRect.Fill = new SolidColorBrush(Colors.LightGray);
                    }


                    thisRect.MouseDown += ((MainWindow)Application.Current.MainWindow).OnClicked;



                    BoardGrid.Children.Add(thisRect);


                    GameCon.ViewMap.Add(GetSquare(i, j), thisRect);


                }


            }
        }


        public void AddTextBlock(Rectangle rect)
        {
            int c = Grid.GetColumn(rect);
            int r = Grid.GetRow(rect);
            //need to be abel to check in teh label is already there
            //get teh square for this rect 




            //var result = from element in boardGrid.Children.OfType<TextBlock>() let textblock = element as TextBlock where textblock!= null select textblock;


            TextBlock text = new TextBlock();
            text.Text = "X";
            text.IsHitTestVisible = false;

            BoardGrid.Children.Add(text);

            Grid.SetColumn(text, c);
            Grid.SetRow(text, r);
        }

        public void AddTextBlock(Square square)
        {
            Rectangle rect = GetRect(square);

            int c = Grid.GetColumn(rect);
            int r = Grid.GetRow(rect);
            //need to be abel to check in teh label is already there
            //get teh square for this rect 




            //var result = from element in boardGrid.Children.OfType<TextBlock>() let textblock = element as TextBlock where textblock!= null select textblock;


            TextBlock text = new TextBlock();
            text.Text = "X";
            text.IsHitTestVisible = false;

            BoardGrid.Children.Add(text);

            Grid.SetColumn(text, c);
            Grid.SetRow(text, r);
        }

        public void RemoveTextBlock(Rectangle rect)
        {
            TextBlock textBlock  = CheckForTextBlock(rect);
            if (textBlock != null)
                BoardGrid.Children.Remove(textBlock);

        }

        public TextBlock CheckForTextBlock(Rectangle rect)
        {
          
            //TextBlock foundTextBlock = null;
            
            var result =
                from element
                in BoardGrid.Children.OfType<TextBlock>()
                where
                    (element != null) &&
                    (Grid.GetColumn(element) == Grid.GetColumn(rect)) &&
                    (Grid.GetRow(element) == Grid.GetRow(rect))
                select element;

            return result.FirstOrDefault();
        }
    }
}
