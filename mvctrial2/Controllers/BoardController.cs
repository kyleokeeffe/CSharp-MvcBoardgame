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

using Microsoft.Extensions.DependencyInjection;

namespace mvctrial2.Controllers
{
    public sealed class BoardController
    {
        
        private BoardController() { }

         public static BoardController Instance { get { return Nested.instance; } }

        private class Nested
        {
            static Nested() { }
            internal static readonly BoardController instance = CreateBC();
        }
        private static BoardController CreateBC()
        {
            BoardController bc = new BoardController();
            bc.InitializeBC();
            InitializeService();

            //register service
            //bc.AttachService();
            
            return bc;
        }
        public static void InitializeService()
        {
            ServiceProvider serviceProvider = ((App)Application.Current).GetService();
            var serviceOperation = serviceProvider.GetService<ISingletonOperation>();
            serviceOperation.BuildGameCon();
        }
        // private ControllerService cs;

        private Grid _BoardGrid;
      
        
        public Grid BoardGrid { get { return this._BoardGrid; } set { this._BoardGrid = value; } }

        //private ServiceProvider serviceProvider;
        public void Serve() { }

        public void InitializeBC()
        {
            BoardGrid = ((MainWindow)Application.Current.MainWindow).boardGrid;
        }
        /*public void AttachService()
        {
            cs = ControllerService.Instance;
            cs.BoardCon = this;
        }*/

        public GameController GetGameService()
        {
            ServiceProvider serviceProvider = ((App)Application.Current).GetService();
            var serviceOperation = serviceProvider.GetService<ISingletonOperation>();
            GameController GameCon = serviceOperation.GameCon;
            return GameCon;
        }
        public Square GetSquare(Rectangle rect)
        {
             ServiceProvider serviceProvider = ((App)Application.Current).GetService();
            var serviceOperation= serviceProvider.GetService<ISingletonOperation>();
            GameController GameCon = serviceOperation.GameCon;
            Square associatedSquare = GameCon.ViewMap.FirstOrDefault(keyValuePair => keyValuePair.Value == rect).Key;

            return associatedSquare;
        }

        public Square GetSquare(int x, int y)
        {
            Rectangle rect = GetRect(x, y);


            Square associatedSquare = GetGameService().ViewMap.FirstOrDefault(keyValuePair => keyValuePair.Value == rect).Key;

    
            return associatedSquare;
           
        }

        public Rectangle GetRect(int x, int y)
        {
            var query = GetGameService().ViewMap.Keys.AsQueryable<Square>().Where<Square>(thing => thing.X == x && thing.Y == y);
            bool keyFound = false;
            Rectangle foundRect = new Rectangle();
            foreach (var key in query)
            {
                keyFound = GetGameService().ViewMap.TryGetValue(key, out Rectangle thing);
                if (keyFound == true)
                {
                    foundRect = GetGameService().ViewMap[key];
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
            var query = GetGameService().ViewMap.Keys.AsQueryable<Square>().Where<Square>(thing => thing.X == square.X && thing.Y == square.Y);
            bool keyFound = false;
            Rectangle foundRect = new Rectangle();
            foreach (var key in query)
            {
                keyFound = GetGameService().ViewMap.TryGetValue(key, out Rectangle thing);
                if (keyFound == true)
                {
                    foundRect = GetGameService().ViewMap[key];
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
                    Square thisSquare = new Square(i, j);
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
                    GetGameService().Game.Board.Squares.Add(thisSquare);

                    GetGameService().ViewMap.Add(thisSquare, thisRect);


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
