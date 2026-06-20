using System;

namespace ConnectFour
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, char symbol)
            : base(name, symbol)
        {
        }

        public override int GetMove()
        {
            int column;

            while (true)
            {
                Console.Write($"\n{Name} ({Symbol}), choose a column (1-7): ");

                if (int.TryParse(Console.ReadLine(), out column))
                {
                    if (column >= 1 && column <= 7)
                    {
                        return column - 1;
                    }
                }

                Console.WriteLine("Invalid input! Please enter a number from 1 to 7.");
            }
        }
    }
}