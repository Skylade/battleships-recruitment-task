using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using battleships.GameObjects.Boards;

namespace battleships.GameObjects
{
    public class Game
    {
        private readonly Player _player1;
        private readonly Player _player2;

        public Game()
        {
            _player1 = new Player("Player 1");
            _player2 = new Player("Player 2");

            //Arrange players ships on game boards
            _player1.PlaceShips();
            _player2.PlaceShips();
        }

        /// <summary>
        /// Method prints game and fire boards of each players.
        /// </summary>
        private void PrintPlayersBoards()
        {
            _player1.PrintBoards();
            _player2.PrintBoards();
        }

        /// <summary>
        /// Method responsible for executing single round.
        /// </summary>
        public void NewRound()
        {
            // Determine where to fire
            var firedShotCoordinates = _player1.Fire();

            // Change opponent board
            var shotResult = _player2.ProcessShot(firedShotCoordinates);

            // Change player board
            _player1.ProcessShotResult(shotResult, firedShotCoordinates);

            if (_player2.HasPlayerLost())
            {
                // Determine where to fire
                var firedShotCoordinates2 = _player2.Fire();

                // Change opponent board
                var shotResult2 = _player1.ProcessShot(firedShotCoordinates2);

                // Change player board
                _player2.ProcessShotResult(shotResult2, firedShotCoordinates2);
            }
        }
        /// <summary>
        /// Method with the game loop.
        /// </summary>
        public void Start()
        {
            var endGame = false;
            var shotsNumber = 0;

            while (!endGame)
            {
                if (_player1.HasPlayerLost() && _player2.HasPlayerLost())
                {
                    NewRound();
                    shotsNumber++;
                }
                else endGame = true;
            }

            //After the game is over, print players game and fire board
            PrintPlayersBoards();

            if (_player1.HasPlayerLost())
            {
                Console.WriteLine(_player1.PlayerName + "has won in " + shotsNumber + " shots!");
            }
            else
            {
                Console.WriteLine(_player2.PlayerName + "has won in " + shotsNumber + " shots!");
            }
        }

        /// <summary>
        /// Functions prints passed coordinates. Useful for debugging.
        /// </summary>
        /// <param name="chosenCoordinates"></param>
        /// <param name="playerName"></param>
        private void PrintChosenCoordinates(Coordinates chosenCoordinates, string playerName)
        {
            Console.WriteLine(playerName + "Shoot " + chosenCoordinates.X + " " + chosenCoordinates.Y);
        }
    }
}
