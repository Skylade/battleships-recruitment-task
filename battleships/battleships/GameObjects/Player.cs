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

        public void placeShips()
        {
            _gameBoard.PlaceShipsOnBoard(ShipsList);
        }

        public void PrintBoards()
        {
            Console.WriteLine("Player: " + PlayerName);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(" " + _gameBoard.FieldAt(i,j).FieldType + " ");    
                }
                Console.WriteLine("");
            }
        }
    }
}
