using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using battleships.GameObjects.Boards;

namespace battleships.GameObjects
{
    class Player
    {
        public Player(string playerName)
        {
            PlayerName = playerName;
        }

        public string PlayerName { get; set; }
        private readonly GameBoard _gameBoard = new GameBoard();
        private readonly FireBoard _fireBoard = new FireBoard();

        public void PrintBoards()
        {
            Console.WriteLine("Player: " + PlayerName);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(_gameBoard.FieldTypeAt(i,j));    
                }
                Console.WriteLine("");
            }
        }
    }
}
