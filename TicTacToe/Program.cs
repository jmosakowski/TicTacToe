using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerNameA = "";
            string playerNameB = "";
            char playerSymbolA = 'x';
            char playerSymbolB = 'o';
            char[,] board = new char[3, 3];

            Console.Write("Enter the name of player A: ");
            playerNameA = Console.ReadLine();
            Console.Write("Enter the name of player B: ");
            playerNameB = Console.ReadLine();

            // ...
        }
    }
}
