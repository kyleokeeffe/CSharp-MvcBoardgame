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
using Microsoft.Extensions.DependencyInjection;
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

        private GameController GameConService;
         private BoardController BoardConService;
         private PieceController PieceConService;

  
        
      
        public MainWindow()
        {
            
            InitializeComponent();
           

            
         
      


            GetGameService().InitiateGame();
            GetGameService().PlacePieces();
           

        

        }
        public BoardController GetBoardService()
        {
            ServiceProvider serviceProvider = ((App)Application.Current).GetService();
            var serviceOperation = serviceProvider.GetService<ISingletonOperation>();
            BoardController BoardCon = serviceOperation.BoardCon;
            return BoardCon;
        }
        public GameController GetGameService()
        {
            ServiceProvider serviceProvider = ((App)Application.Current).GetService();
            var serviceOperation = serviceProvider.GetService<ISingletonOperation>();
            GameController GameCon = serviceOperation.GameCon;
            return GameCon;
        }
        public PieceController GetPieceService()
        {
            ServiceProvider serviceProvider = ((App)Application.Current).GetService();
            var serviceOperation = serviceProvider.GetService<ISingletonOperation>();
            PieceController PieceCon = serviceOperation.PieceCon;
            return PieceCon;
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

            Square senderAsSquare = GetBoardService().GetSquare(senderAsRect);
            //MessageBox.Show(senderAsSquare.ToString());
            if (senderAsSquare.Piece != null)
            {
                List<Square> legalMoves = GetPieceService().GetLegalMoves(senderAsSquare.Piece);
                foreach (Square legalMove in legalMoves)
                {
                    GetBoardService().AddTextBlock(legalMove);
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
            
          
           
            Square associatedSquare = GetBoardService().GetSquare(senderAsRect);
            Piece occupyingPiece;

          

        }
        

        

    }
}
