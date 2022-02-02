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

        private GameController GameCon;
         private BoardController BoardCon;
         private PieceController PieceCon;

        private ControllerService cs;
        
      
        public MainWindow()
        {
            
            InitializeComponent();

            cs = ControllerService.Instance;
         
            cs.InitializeService();


            GameCon = cs.GameCon;
            BoardCon = cs.BoardCon;
            PieceCon = cs.PieceCon;
            

            GameCon.InitiateGame();
            GameCon.PlacePieces();
           

        

        }
       

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

       
       internal void OnClicked(object sender, MouseButtonEventArgs e)
        {

          
              
            Rectangle senderAsRect = (Rectangle)sender;
            //senderAsRect.Fill = new SolidColorBrush(Colors.Pink);

            Square senderAsSquare = BoardCon.GetSquare(senderAsRect);
            //MessageBox.Show(senderAsSquare.ToString());
            if (senderAsSquare.Piece != null)
            {
                List<Square> legalMoves = PieceCon.GetLegalMoves(senderAsSquare.Piece);
                foreach (Square legalMove in legalMoves)
                {
                    BoardCon.AddTextBlock(legalMove);
                    MessageBox.Show($"{senderAsSquare.X}, {senderAsSquare.Y} -  {legalMove.X}, {legalMove.Y}");
                }
                //MessageBox.Show("piece");

            }
            else
                MessageBox.Show("no piece");
               // senderAsRect.Fill = new SolidColorBrush(Colors.Blue);

          /* TextBlock textBlock = BoardCon.CheckForTextBlock(senderAsRect);
            if (textBlock == null)
                BoardCon.AddTextBlock(senderAsRect);
            else
                BoardCon.RemoveTextBlock(senderAsRect);
          */
           // AlertRectInfo();
            
          
           
            Square associatedSquare = BoardCon.GetSquare(senderAsRect);
            Piece occupyingPiece;

          

        }
        

        

    }
}
