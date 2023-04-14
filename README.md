# WPF Checkers Game
Authors: Connor Walsh, Daniel Cunningham
Date: 4/14/2023

## How to Run
* Press the play button in Visual Studio to run the program.
* Once the program has been loaded, the user may start a local checkers game by pressing the "Local Game" button or change the color of the checker board by clicking the "Settings" button. 
* Once the checkers game has been loaded, the player wins when all of the other players pieces are taken or a player forfeits the game. 
* Press "Quit Game" to exit the program. 

## Design Decisions
* This game is a fully functional checkers game, however, the ability to perform multiple hops in one turn is not currently included in this version of the game. This ability is not allowed in some versions of checkers, so this is a fully functional checkers game.
* The user has the ability to change the color of the checkers board which has been accompished by using the factory design pattern. The buttons in the "Settings" window call the factory and set the color of the squares on the board. 
* The attributes that the various pieces have, including the King piece, have been implemented using the decorator design pattern. 
* Network play is currently in development, but has not been completed yet.
