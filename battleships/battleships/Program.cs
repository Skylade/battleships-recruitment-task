using System;
using System.IO;
using battleships.GameObjects;

namespace battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Battleships!");

            var game = new Game();

            game.Start();

        }
    }
}
