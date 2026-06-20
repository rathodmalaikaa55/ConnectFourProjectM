using System;

namespace ConnectFour
{
    public class GameController
    {
        private Board board;
        private Player player1;
        private Player player2;

        public void StartGame()
        {
            Console.WriteLine("========== CONNECT FOUR ==========\n");

            Console.Write("Enter Player 1 Name: ");
            string player1Name = Console.ReadLine();

            Console.Write("Enter Player 2 Name: ");
            string player2Name = Console.ReadLine();

            player1 = new HumanPlayer(player1Name, 'X');
            player2 = new HumanPlayer(player2Name, 'O');

            bool playAgain = true;

            while (playAgain)
            {
                board = new Board();

                Player currentPlayer = player1;

                while (true)
                {
                    board.DisplayBoard();

                    int column = currentPlayer.GetMove();

                    if (!board.DropPiece(column, currentPlayer.Symbol))
                    {
                        Console.WriteLine("\nColumn is full!");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    if (board.CheckWinner(currentPlayer.Symbol))
                    {
                        board.DisplayBoard();

                        Console.WriteLine($"🎉 {currentPlayer.Name} Wins! 🎉");
                        break;
                    }

                    if (board.IsFull())
                    {
                        board.DisplayBoard();

                        Console.WriteLine("Game ended in a Draw!");
                        break;
                    }

                    currentPlayer =
                        currentPlayer == player1
                        ? player2
                        : player1;
                }

                Console.Write("\nPlay Again? (Y/N): ");

                string answer = Console.ReadLine().ToUpper();

                playAgain = answer == "Y";
            }
        }
    }
}