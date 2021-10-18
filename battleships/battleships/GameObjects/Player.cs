using System;
using System.Collections.Generic;
using System.Linq;
using battleships.GameObjects.Boards;
using battleships.GameObjects.Ships;

namespace battleships.GameObjects
{
    class Player
    {
        public Player(string playerName)
        {
            PlayerName = playerName;
            ShipsList = new List<Ship>()
            {
                new Battleship(),
                new Carrier(),
                new Cruiser(),
                new Destroyer(),
                new Submarine()
            };
        }

        public string PlayerName { get; set; }
        public List<Ship> ShipsList { get; set; }
        private readonly GameBoard _gameBoard = new GameBoard();
        private readonly FireBoard _fireBoard = new FireBoard();

        public bool HasPlayerLost()
        {
            return ShipsList.Any(ship => ship.HasSunk() == false);
        }

        /// <summary>
        /// Method returns randomly selected coordinates.
        /// </summary>
        /// <returns></returns>
        public Coordinates Fire()
        {
            var rn = new Random();
            var availableFields = _fireBoard.GetAvailableFieldsList();
            var availableFieldNumber = rn.Next(availableFields.Count);

            return availableFields[availableFieldNumber].Coordinates;
        }

        /// <summary>
        /// Method changes the fire board based on the passed shot results and coordinates.
        /// </summary>
        /// <param name="shotResult"></param>
        /// <param name="firedShotCoordinates"></param>
        public void ProcessShotResult(char shotResult, Coordinates firedShotCoordinates)
        {
            var shotField = _fireBoard.Fields.First(field => field.Coordinates.X == firedShotCoordinates.X && field.Coordinates.Y == firedShotCoordinates.Y);

            // Change field status
            shotField.FieldType = shotResult;
        }

        /// <summary>
        /// Method processes shot based on its coordinates. Returns type of field based on calculations - hit, miss or sink.
        /// </summary>
        /// <param name="firedShotCoordinates"></param>
        /// <returns></returns>
        public char ProcessShot(Coordinates firedShotCoordinates)
        {
            var shotField = _gameBoard.Fields.First(field => field.Coordinates.X == firedShotCoordinates.X && field.Coordinates.Y == firedShotCoordinates.Y);

            if (shotField.FieldType == (char)FieldTypes.Empty)
            {
                shotField.FieldType = (char)FieldTypes.Miss;
                return (char)FieldTypes.Miss;
            }

            var hitShip = ShipsList.First(ship => ship.ScreenSymbol == shotField.FieldType);

            // Increment ship hits
            hitShip.Hits++;

            // Change field status
            shotField.FieldType = (char)FieldTypes.Hit;

            if (hitShip.HasSunk())
            {
                Console.WriteLine("Sink");
                return (char)FieldTypes.Hit;
            }

            Console.WriteLine("Hit");
            return (char)FieldTypes.Hit;

        }

        /// <summary>
        /// Method invokes method responsible for placing the ships on the player board.
        /// </summary>
        public void PlaceShips()
        {
            _gameBoard.PlaceShipsOnBoard(ShipsList);
        }

        /// <summary>
        /// Method prints fire and game board of the player.
        /// </summary>
        public void PrintBoards()
        {
            Console.WriteLine("Player game board: " + PlayerName);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(" " + _gameBoard.FieldAt(i, j).FieldType + " ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("Player fire board: " + PlayerName);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(" " + _fireBoard.FieldAt(i, j).FieldType + " ");
                }
                Console.WriteLine("");
            }

        }
    }
}
