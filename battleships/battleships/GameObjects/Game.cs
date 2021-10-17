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

            _player1.PlaceShips();
            _player2.PlaceShips();

            
        }

        void PrintPlayersBoards()
        {
            _player1.PrintBoards();
            _player2.PrintBoards();
        }

        public void NewRound()
        {

        }

        public void Start()
        { 
            //var endGame = false


            PrintPlayersBoards();

            var firedShotCoordinates = _player1.Fire();
            var shotResult = _player2.ProcessShot(firedShotCoordinates);
            // _player1.ProcessShotResult();

            PrintChosenCoordinates(firedShotCoordinates, _player1.PlayerName);
            Console.WriteLine("Player 1 " + shotResult);
            PrintPlayersBoards();

            /*firedShotCoordinates = _player2.Fire();
            shotResult = _player1.ProcessShot(firedShotCoordinates);
            _player2.ProcessShotResult();

            Console.WriteLine("Player 2 " + shotResult);*/
        }

        private void PrintChosenCoordinates(Coordinates chosenCoordinates, string playerName)
        {
            Console.WriteLine(playerName + "Shoot " + chosenCoordinates.X + " " + chosenCoordinates.Y);
        }
    }
}
