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

namespace mvctrial2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public delegate void ClickedEventHandler(Rectangle sender, MouseButtonEventArgs e);
    public partial class MainWindow : Window
    {
        
        GameController gameCon;
    
        public MainWindow()
        {
            InitializeComponent();
   
            gameCon = new GameController();

  

            BuildBoard();


            //make following into method for AddTextToSquare / RemoveTextFromSquare
            Rectangle selectedRect = GetSquareRect(5, 5);
                selectedRect.Fill = new SolidColorBrush(Colors.Red);

            int c = Grid.GetColumn(selectedRect);
            int r = Grid.GetRow(selectedRect);

            TextBlock text = new TextBlock();
            text.Text = "X";

            boardGrid.Children.Add(text);
            Grid.SetColumn(text, c);
            Grid.SetRow(text, r);

        

        }

       protected void OnClicked(object sender, MouseButtonEventArgs e)
        {
         
            Rectangle senderCasted = (Rectangle)sender;
            senderCasted.Fill =new SolidColorBrush(Colors.Pink);
            MessageBox.Show($" {sender.ToString()} {e.GetPosition(boardGrid).X.ToString()},{e.GetPosition(boardGrid).Y.ToString()}");

            //switch statement for attribute of sender = does it have a piuece on the associated square 
            //or, since addign a label to the grid cell places the lavbel above the retangle, could have, if sender is text type 
        }
        

        public Rectangle GetSquareRect(int x, int y)
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
              

                    thisRect.MouseDown += OnClicked;

                  
                    
                    boardGrid.Children.Add(thisRect);


                    gameCon.ViewMap.Add(gameCon.GetSquare(i, j), thisRect);


                }


            }
        }
        

    }
}
