using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create two players
            HumanPlayer p1 = new HumanPlayer() { Name = "JacekM", Symbol = 'x' };
            ComputerPlayer p2 = new ComputerPlayer() { Name = "AI", Symbol = 'o' };

            // Create two arrays - one for the game board, and one saying if a place is taken
            char[,] board = {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };
            int height = board.GetLength(0);
            int width = board.GetLength(1);
            bool[,] takenPlaces = new bool[height, width];  // initially all false by default

            // Flags
            bool player1Won = false;
            bool player2Won = false;
            bool nextIsPlayer1 = true;                      // true: player1 move, false: player2 move

            ////////////////////////////////////////////////////////////////

            // Loop over rounds
            for (int round = 0; round < board.Length; round++)
            {
                Console.Clear();
                Draw(board);

                if (nextIsPlayer1)
                {
                    Console.WriteLine(p1.Name + " move");
                    player1Won = p1.MakeMove(board, takenPlaces);
                    nextIsPlayer1 = false;
                }
                else
                {
                    Console.WriteLine(p2.Name + " move");
                    player2Won = p2.MakeMove(board, takenPlaces);
                    nextIsPlayer1 = true;
                }

                if (player1Won || player2Won)
                    break;
            }

            ////////////////////////////////////////////////////////////////

            // Game end
            Console.Clear();
            Draw(board);

            Console.Write("Game ended! ");
            if (player1Won)
                Console.WriteLine("Winner: " + p1.Name);
            else if (player2Won)
                Console.WriteLine("Winner: " + p2.Name);
            else
                Console.WriteLine("A tie!");

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }

        /******************************************************************/

        static void Draw(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                    Console.Write(board[i, j]);
                Console.WriteLine();
            }
        }
    }
}
