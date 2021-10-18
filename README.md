### Battleship recruitment task

#### Objective

Based on the rules of the Battleship board game (https://en.wikipedia.org/wiki/Battleship_(game)) implement a program that randomly places ships on two boards and simulates the gameplay between 2 players.

The app should be the default C# console app. Due to the fact that the app is quite simple and I work alone, I won't be using too many git features (branches, etc.).

#### Game rules

I opted for the classic version of the game based on its original rules.

The game is played on four boards, two for each player. The boards are square - 10×10 – and the individual squares (fields) in the board are identified by 2 coordinates - X and Y. On one board (game board) the player arranges ships and records the shots by the opponent. On the other board (fire board) the player records their shots. There are no repetitions of firing.

Before play begins, each player secretly arranges their ships on their game board (the placement of ships is generated randomly). Each ship occupies a number of consecutive squares on the board, arranged either horizontally or vertically. The number of squares for each ship is determined by the type of ship. The ships cannot overlap (i.e., only one ship can occupy any given square in the board). The types and numbers of ships allowed are the same for each player.

The classic version of the rules specify the following ships:

| No. | Class of ship | Size | Symbol |
| :-: | :-----------: | :--: | :----: |
|  1  |    Carrier    |  5   |   C    |
|  2  |  Battleship   |  4   |   B    |
|  3  |    Cruiser    |  3   |   P    |
|  4  |   Submarine   |  3   |   S    |
|  5  |   Destroyer   |  2   |   D    |

After the ships have been positioned, the game proceeds in a series of rounds. In each round, each player takes a turn to announce a target square in the opponent's board which is to be shot at. The opponent announces whether or not the square is occupied by a ship. If it is a "hit", the player who is hit marks this on their own or "ocean" board (with a letter "H"). The attacking player marks the hit or miss on their own fire board ("H" for "hit", M for "miss"), in order to build up a picture of the opponent's fleet. The empty field is represented by "o".

When all of the squares of a ship have been hit, the ship's owner announces the sinking of the Carrier, Submarine, Cruiser/Destroyer/Patrol Boat, or the titular Battleship. If all of a player's ships have been sunk, the game is over and their opponent wins.

#### Process of creating the game

The game development process consists of the following stages:

-   creating the board and fill it with ships for each player
-   creating the system of generating the bullets and determine if the fire was hit or miss
-   creating a game loop and determine when the game should end
-   final refactoring

The game is written with an object-oriented paradigm in mind. The main steps are in the history of commits on GitHub.

The currently implemented fire algorithm generates random coordinates. It is a naive implementation and it can be optimized, e.g. by selecting another field in the area after a random shot. The type of algorithm and its performance weren't specified in the requirements. I opted for this one, so as to hand over the tasks as soon as possible.
