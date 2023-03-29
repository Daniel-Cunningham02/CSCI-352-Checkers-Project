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
using CheckersProject.src;
using System.Threading;
using System.Linq.Expressions;
using System.Runtime.Remoting.Channels;
using System.ComponentModel;

namespace CheckersProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Board : Window
    {
        private bool FirstClick;
        Piece previousClick;
        Player player;
        public Board() //Button b //need to pass in the parameters for the color change
        {
            /* Start here to understand this branch*/
            InitializeComponent();
            FirstClick = false;

            player = new Player(this); // Have to pass in this because the player class takes in a Board object as a parameter
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        // Creates button and adds it to the grid along with its color.
                        Button button = new Button {
                            Name = ("Button" + i.ToString() + j.ToString()),
                            Background = Brushes.Black
                        };
                        RegisterName(button.Name, button); /* Have to register the name with the button because they aren't bound
                        automatically when created programmatically. Name is later used to access the button and its content(piece image).*/
                        button.Click += new RoutedEventHandler(Move_Button_Click); // Creates new EventHandler for the button because there is not a handler made automatically.
                        Grid.SetRow(button, i);
                        Grid.SetColumn(button, j);
                        grid.Children.Add(button);

                        Pos pos = new Pos(i, j);
                        if (i < 3)  // Different pieces are created depending upon their position on the board
                        {
                            BlackPieceDecorator piece = new BlackPieceDecorator(null, pos); 
                            player.SetPiece(pos, piece); // Sets the piece in the 2D array and updates the button's content(image) on the grid.
                        }
                        else if(i > 4)
                        {
                            RedPieceDecorator piece = new RedPieceDecorator(null, pos);
                            player.SetPiece(pos, piece);
                        }
                        else
                        {
                            BlankPiece piece = new BlankPiece(null, new Pos(i, j)); // Blank piece is used as a placeholder for place where the pieces can move.
                            player.SetPiece(pos, piece);
                        }
                    }
                    else
                    {
                        // Creating button here too not for functionality but for styling.
                        Button button = new Button
                        {
                            Background = Brushes.Red
                        };
                        //Button button = new Button(); //the problem here might be that the same button is being used
                        //button = b;
               
                        Grid.SetRow(button, i);
                        Grid.SetColumn(button, j);
                        grid.Children.Add(button);
                    }

                }
            }
            this.ResizeMode = ResizeMode.NoResize;
            
        }


        private void Move_Button_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = (Button)sender; // Typecasts sender object to button.
            int row = Int32.Parse(clicked.Name.Substring(6,1)); 
            /* Parses the substring of button names to find the row and column. Button names
             * are formatted as such "Button" + Row + Column. Also had to use substring here because
             * Int32.Parse can only parse strings and Convert.ToInt32 takes the ascii value */
            int col = Convert.ToInt32(clicked.Name.Substring(7));
            if (FirstClick == false)
            {
                FirstClick = true; //Find a way to keep the hover effect for mouse here
                /* Uses bool FirstClick here to account for having to click twice */
                previousClick = player.GetPiece(new Pos(row, col));
                player.CheckValidMoves(previousClick);
            }
            else
            {
                player.Move(new Pos(row, col), previousClick);
                FirstClick = false;
            }
            
        }
        private void Quit_Button_Click(object sender, RoutedEventArgs e)
        {
            
            Menu m  = new Menu();
            this.Close();
            m.Show();
        }
    }
}
