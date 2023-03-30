﻿using System;
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

namespace CheckersProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Board : Window
    {
        private bool FirstClick;
        private Piece previousClick;
        private Button previousClickedButton;
        private Player player;
        private SolidColorBrush Hovered;
        private GameType gameType;


        public Board(GameType type, string ip)
        {
            gameType = type;
            this.Icon = new BitmapImage(new Uri("..\\..\\CheckerRedTransparent.png", UriKind.Relative));
            /* Start here to understand this branch*/
            InitializeComponent();
            FirstClick = false;
            Hovered = new SolidColorBrush(Color.FromRgb(50, 255, 50));
            if (type == GameType.LAN)
            {
                player = new LANPlayer(this);// Have to pass in this because the player class takes in a Board object as a parameter
            }
            else if(type == GameType.MultiplayerHost)
            {
                player = new Host(this);
                Ip.Text = "Ip " + ((Host)player).getObs().IP;


            }
            else if(type == GameType.MultiplayerJoin)
            {
                player = new JoinedPlayer(this, ip);
            }
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 1)
                    {
                        // Creates button and adds it to the grid along with its color.
                        Button button = new Button
                        {
                            Name = ("Button" + i.ToString() + j.ToString()),
                            Background = Brushes.Black,
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
                        else if (i > 4)
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

                        Grid.SetRow(button, i);
                        Grid.SetColumn(button, j);
                        grid.Children.Add(button);
                    }

                }
            }

            Player_1_Amount.Text = "12";
            Player_2_Amount.Text = "12";
            this.ResizeMode = ResizeMode.NoResize;
            player.State = GameState.redTurn;
            if (gameType == GameType.MultiplayerJoin)
            {
                ((JoinedPlayer)player).Connect();
            }
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
                if(player.State == GameState.redTurn && player.GetPiece(new Pos(row, col)).ToString() != "CheckersProject.src.RedPieceDecorator")
                {
                    return;
                    
                    
                }
                else if(player.State == GameState.blackTurn && player.GetPiece(new Pos(row, col)).ToString() != "CheckersProject.src.BlackPieceDecorator")
                {
                    return;
                }
                previousClick = player.GetPiece(new Pos(row, col));
                FirstClick = true; //Find a way to keep the hover effect for mouse here
                /* Uses bool FirstClick here to account for having to click twice */

                if(previousClick.ToString() != "CheckersProject.src.BlankPiece")
                {
                    FirstClick = true; //Find a way to keep the hover effect for mouse here
                    /* Uses bool FirstClick here to account for having to click twice */

                    clicked.Background = Hovered;
                    previousClickedButton = clicked;
                    player.CheckValidMoves(previousClick);
                    player.HighlightValidMoves(previousClick);
                }
                else
                {
                    return;
                }
            }
            else
            {
                FirstClick = false;

                previousClickedButton.Background = Brushes.Black;
                if(player.Move(new Pos(row, col), previousClick))
                {
                    if(Int32.Parse(Player_1_Amount.Text) != 0 && Int32.Parse(Player_2_Amount.Text) != 0)
                    {
                        player.State = (GameState)(-((int)player.State));
                    }
                    else if(Int32.Parse(Player_1_Amount.Text) == 0)
                    {
                        player.State = GameState.blackWin;
                    }
                    else
                    {
                        player.State = GameState.redWin;
                    }
                }
                if(player.GetPiece(new Pos(row, col)).CheckPromotion())
                {
                    player.GetPiece(new Pos(row, col)).updateImage(this);
                }
                
            }
            CheckWin();
        }

        private void CheckWin()
        {
            if(player.State == GameState.blackWin)
            {
                MessageBox.Show("Congrats! Blue wins!");
                Menu m = new Menu();
                this.Close();
                m.Show();
            }
            else if(player.State == GameState.redWin)
            {
                // Finish here
                MessageBox.Show("Congrats! Red wins!");
                Menu m = new Menu();
                this.Close();
                m.Show();
            }
            else
            {
                return;
            }
        }
        private void Quit_Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.gameType == GameType.MultiplayerHost)
            {
                ((Host)player).getObs().Close();
            }
            else if(this.gameType == GameType.MultiplayerJoin)
            {
                ((JoinedPlayer)player).Close();
            }
            Menu m  = new Menu();
            this.Close();
            m.Show();
        }
    }
}
