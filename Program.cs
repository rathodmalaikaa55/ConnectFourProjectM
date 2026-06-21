using System;

namespace ConnectFour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameController game = new GameController();
            game.StartGame();

            Console.WriteLine("\nThanks for playing!");
            Console.ReadKey();
        }
    }
}  

