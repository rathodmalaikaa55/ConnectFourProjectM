using System;

namespace ConnectFour
{
    public class Board
    {
        private char[,] grid;

        public Board()
        {
            grid = new char[6, 7];

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    grid[row, col] = '.';
                }
            }
        }

        public void DisplayBoard()
        {
            Console.Clear();

            Console.WriteLine("========== CONNECT FOUR ==========\n");

            Console.WriteLine(" 1 2 3 4 5 6 7");

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Console.Write(" " + grid[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public bool DropPiece(int column, char symbol)
        {
            for (int row = 5; row >= 0; row--)
            {
                if (grid[row, column] == '.')
                {
                    grid[row, column] = symbol;
                    return true;
                }
            }

            return false;
        }

        public bool IsFull()
        {
            for (int col = 0; col < 7; col++)
            {
                if (grid[0, col] == '.')
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckWinner(char symbol)
        {
            // Horizontal
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (grid[row, col] == symbol &&
                        grid[row, col + 1] == symbol &&
                        grid[row, col + 2] == symbol &&
                        grid[row, col + 3] == symbol)
                    {
                        return true;
                    }
                }
            }

            // Vertical
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (grid[row, col] == symbol &&
                        grid[row + 1, col] == symbol &&
                        grid[row + 2, col] == symbol &&
                        grid[row + 3, col] == symbol)
                    {
                        return true;
                    }
                }
            }

            // Diagonal Down-Right
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (grid[row, col] == symbol &&
                        grid[row + 1, col + 1] == symbol &&
                        grid[row + 2, col + 2] == symbol &&
                        grid[row + 3, col + 3] == symbol)
                    {
                        return true;
                    }
                }
            }

            // Diagonal Up-Right
            for (int row = 3; row < 6; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if (grid[row, col] == symbol &&
                        grid[row - 1, col + 1] == symbol &&
                        grid[row - 2, col + 2] == symbol &&
                        grid[row - 3, col + 3] == symbol)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}