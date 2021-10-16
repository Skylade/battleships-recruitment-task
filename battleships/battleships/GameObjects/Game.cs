using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

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
        }

        public void NewRound()
        {

        }

        public void Start()
        {
            _player1.PrintBoards();
            _player1.placeShips();
            _player1.PrintBoards();
        }
    }
}
