using mvctrial2.Controllers;
using mvctrial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using mvctrial2.Services;


namespace mvctrial2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public delegate void ClickedEventHandler(Rectangle sender, MouseButtonEventArgs e);
    public partial class MainWindow : Window
    {

        //private GameController GameCon;
        // private BoardController BoardCon;
        // private PieceController PieceCon;
        //private Grid grid;
        //private ControllerService ContServ;
        //public GameController GameCon { get { return this._GameCon; } set { this._GameCon = value; } }
        // public BoardController BoardCon { get { return this._BoardCon; } set { this._BoardCon = value; } }
        private ControllerService cs;
        public MainWindow()
        {
            //ContServ=new ControllerService();
            InitializeComponent();
            cs = new ControllerService();
            // grid = boardGrid;
            //  GameCon = GameController.GetInstance();
            // BoardCon = BoardController.GetInstance();
            //  PieceCon = PieceController.GetInstance();

            cs.GameCon.DoNothing();
            cs.BoardCon.BuildBoard();


            //make following into method for AddTextToSquare / RemoveTextFromSquare
           /* Rectangle selectedRect = GetSquareRect(5, 5);
                selectedRect.Fill = new SolidColorBrush(Colors.Red);

            int c = Grid.GetColumn(selectedRect);
            int r = Grid.GetRow(selectedRect);
         
            TextBlock text = new TextBlock();
            text.Text = "X";
            text.IsHitTestVisible = false;

            boardGrid.Children.Add(text);
       
            Grid.SetColumn(text, c);
            Grid.SetRow(text, r);*/


        

        }
        /*public bool CheckForLabel(Rectangle rect)
        {
            bool labelPresent = false;
            var result = 
                from element 
                in boardGrid.Children.OfType<TextBlock>() 
                where 
                    (element != null) && 
                    (Grid.GetColumn(element) == Grid.GetColumn(rect)) && 
                    (Grid.GetRow(element) == Grid.GetRow(rect)) 
                select element;

            if (result.Count() == 0)
                labelPresent = false;
            else
                labelPresent = true;

            return labelPresent;
        }*/

        public void AlertRectInfo()
        {
            var result = from element in boardGrid.Children.OfType<TextBlock>() where element != null select element;

            string report = "";
            foreach (var thing in result)
            {
                int c = Grid.GetColumn(thing);
                int r = Grid.GetRow(thing);
                report +=$"{c},{r}\n";
            }
            MessageBox.Show(report);
        }

        /*public void PrintLabelOnRect(Rectangle rect)
        {
            int c = Grid.GetColumn(rect);
            int r = Grid.GetRow(rect);
            //need to be abel to check in teh label is already there
            //get teh square for this rect 

            


            //var result = from element in boardGrid.Children.OfType<TextBlock>() let textblock = element as TextBlock where textblock!= null select textblock;
           

            TextBlock text = new TextBlock();
            text.Text = "X";
            text.IsHitTestVisible = false;

            boardGrid.Children.Add(text);

            Grid.SetColumn(text, c);
            Grid.SetRow(text, r);
        }*/
       internal void OnClicked(object sender, MouseButtonEventArgs e)
        {

          
              
            Rectangle senderAsRect = (Rectangle)sender;
            //senderAsRect.Fill = new SolidColorBrush(Colors.Pink);

            Square senderAsSquare = cs.BoardCon.GetSquare(senderAsRect);
            if (senderAsSquare.Piece != null)
            {
                List<Square> legalMoves = cs.PieceCon.GetLegalMoves(senderAsSquare.Piece);
                foreach (var thing in legalMoves)
                {
                    cs.BoardCon.AddTextBlock(thing);
                }

            }
            else
                senderAsRect.Fill = new SolidColorBrush(Colors.Blue);

            TextBlock textBlock = cs.BoardCon.CheckForTextBlock(senderAsRect);
            if (textBlock == null)
                cs.BoardCon.AddTextBlock(senderAsRect);
            else
                cs.BoardCon.RemoveTextBlock(senderAsRect);

            AlertRectInfo();
            
          
               
            //MessageBox.Show($" {sender.ToString()} {e.GetPosition(boardGrid).X.ToString()},{e.GetPosition(boardGrid).Y.ToString()} {sender.GetType().ToString()}");



            //switch statement for attribute of sender = does it have a piuece on the associated square 
            //have rect, query viewmap dictionry for key 

            //turn this into a method: for returnign associated key, and for checking if piece is on rect 
            //Square associatedSquare= gameCon.ViewMap.FirstOrDefault(thing => thing.Value == senderAsRect).Key;
            Square associatedSquare = cs.BoardCon.GetSquare(senderAsRect);
            Piece occupyingPiece;

            /*if (CheckSquareForPiece(associatedSquare) != null)
                occupyingPiece = CheckSquareForPiece(associatedSquare);

            else
                occupyingPiece = null;



            if (occupyingPiece != null) {    
                PrintLabelOnRect(senderAsRect);    //then piece was clicked - do piece pattern 
            }*/
         
                //then square clicked 

        }
        

        /*public Piece CheckSquareForPiece(Square square)
        {
            Piece piece;



            if (square.Piece != null)
                piece = square.Piece;
            else
                piece = null;
            return piece;
        }*/
        /*public Square GetRectSquare(Rectangle rect)
        {
            Square associatedSquare = gameCon.ViewMap.FirstOrDefault(thing => thing.Value == rect).Key;
            return associatedSquare;
        }*/


      /* public Rectangle GetSquareRect(int x, int y)
        {
            var query = gameCon.ViewMap.Keys.AsQueryable<Square>().Where<Square>(thing => thing.X == x && thing.Y == y);
            bool keyFound = false;
            Rectangle foundRect = new Rectangle();
            foreach(var key in query)
            {
                keyFound= gameCon.ViewMap.TryGetValue(key, out Rectangle thing);
                if (keyFound == true)
                {
                    foundRect = gameCon.ViewMap[key];
                }
                else
                {
                    foundRect = null;
                    MessageBox.Show("keynot found");
                }
            }
            return foundRect;
           

        }*/
     /*
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
              

                    thisRect.MouseDown += OnClicked;

                  
                    
                    boardGrid.Children.Add(thisRect);


                    gameCon.ViewMap.Add(gameCon.GetSquare(i, j), thisRect);


                }


            }
        }*/
        

    }
}
