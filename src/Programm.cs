using System;

namespace MyCSharpProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Dungeon Game!");

            Game game = new Game();  // Create an instance of Game
            game.Start();  // Start the game loop
        }
    }
}

