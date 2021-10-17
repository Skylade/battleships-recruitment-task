using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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



        /// <summary>
        /// Method returns randomly selected coordinates. Currently naive solution. 
        /// </summary>
        /// <returns></returns>
        public Coordinates Fire()
        {
            var rn = new Random();
            var availableFields = _gameBoard.GetAvailableFieldsList();
            var availableFieldNumber = rn.Next(availableFields.Count);
            
            return availableFields[availableFieldNumber].Coordinates;
        }

        public void ProcessShotResult()
        {
            

            throw new NotImplementedException();
        }

        public string ProcessShot(Coordinates firedShotCoordinates)
        {
            var shotField = _gameBoard.Fields.First(field => field.Coordinates.X == firedShotCoordinates.X && field.Coordinates.Y == firedShotCoordinates.Y);

            if (shotField.FieldType == (char)FieldTypes.Empty)
            {
                shotField.FieldType = (char)FieldTypes.Miss;
                return "Miss";
            }
            else
            {
                var hitShip = ShipsList.First(ship => ship.ScreenSymbol == shotField.FieldType);

                // Increment ship hits
                hitShip.Hits++;

                // Change field status
                shotField.FieldType = (char) FieldTypes.Hit;

                if (hitShip.HasSunk())
                {
                    return "Sink";
                }

                return "Hit";
            }
        }

        public void PlaceShips()
        {
            _gameBoard.PlaceShipsOnBoard(ShipsList);
        }

        public void PrintBoards()
        {
            Console.WriteLine("Player game board: " + PlayerName);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(" " + _gameBoard.FieldAt(i,j).FieldType + " ");    
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
