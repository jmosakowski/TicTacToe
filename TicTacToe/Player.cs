using System;
using System.Linq;                  // for Cast
using System.Threading;             // for Thread.Sleep

namespace TicTacToe
{
    abstract class Player
    {
        public string Name { get; set; }
        public char Symbol { get; set; }
        protected char chosenPlace; // last place picked by the player

        public bool CheckIfPlayerWon(char[,] board)
        {
            int height = board.GetLength(0);
            int width = board.GetLength(1);
            if (height != width)
                throw new Exception("The board is not square!");

            // Check rows
            for (int i = 0; i < height; i++)
            {
                int rowSum = 0;
                for (int j = 0; j < width; j++)
                {
                    if (board[i, j] == Symbol)
                        rowSum++;
                }
                if (rowSum == width)
                    return true;
            }

            // Check columns
            for (int j = 0; j < width; j++)
            {
                int colSum = 0;
                for (int i = 0; i < height; i++)
                {
                    if (board[i, j] == Symbol)
                        colSum++;
                }
                if (colSum == height)
                    return true;
            }

            // Check diagonals
            int diagSumA = 0;
            int diagSumB = 0;
            for (int k = 0; k < width; k++)
            {
                if (board[k, k] == Symbol)
                    diagSumA++;
                if (board[k, width - 1 - k] == Symbol)
                    diagSumB++;
            }
            if (diagSumA == width || diagSumB == width)
                return true;

            // Otherwise, no win yet
            return false;
        }

        public bool PlaceSymbol(char c, char[,] board, bool[,] takenPlaces)
        {
            int height = board.GetLength(0);
            int width = board.GetLength(1);
            if (height != takenPlaces.GetLength(0) || width != takenPlaces.GetLength(1))
                throw new Exception("The boards have different sizes!");

            // Try to place player's symbol, if the place is available
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    if (board[i, j] == c && !takenPlaces[i, j])
                    {
                        board[i, j] = Symbol;
                        takenPlaces[i, j] = true;
                        return true;
                    }

            // Otherwise, return without success
            return false;
        }
    }

    /**********************************************************************/

    class HumanPlayer : Player
    {
        public bool MakeMove(char[,] board, bool[,] takenPlaces)
        {
            // Keep asking the human player to choose a place until an empty one is picked
            do
            {
                Console.Write("Choose an empty place: ");
                chosenPlace = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
            while (!PlaceSymbol(chosenPlace, board, takenPlaces));

            return CheckIfPlayerWon(board);
        }
    }

    /**********************************************************************/

    class ComputerPlayer : Player
    {
        public bool MakeMove(char[,] board, bool[,] takenPlaces)
        {
            // Keep picking symbols from the board until the AI player picks an empty place
            Thread.Sleep(2000);                                     // wait 2 seconds
            Random rnd = new Random();
            do
            {
                char[] allSymbols = board.Cast<char>().ToArray();   // all symbols in 1D array
                int s = rnd.Next(0, allSymbols.Length);             // pick random symbol
                chosenPlace = allSymbols[s];                        // 
            }
            while (!PlaceSymbol(chosenPlace, board, takenPlaces));

            return CheckIfPlayerWon(board);
        }
    }
}
