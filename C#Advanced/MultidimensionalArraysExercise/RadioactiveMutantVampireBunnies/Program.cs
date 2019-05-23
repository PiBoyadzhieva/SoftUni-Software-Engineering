using System;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    public class Program
    {
        static char[,] board;
        static int playerRow;
        static int playerCol;
        static int rows;
        static int cols;

        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            board = ReadAndFillMatrix(dimensions);

            char[] movements = Console.ReadLine().ToCharArray();

            foreach (var move in movements)
            {
                int[] previousLocation = MovePlayer(move);

                MultiplyBunnies();

                if(isPlayerOnTheBoard())
                {
                    if(board[playerRow, playerCol] == 'B')
                    {
                        Die();
                    }
                }
                else
                {
                    Win(previousLocation);
                }
            }
        }

        private static void Die()
        {
            PrintBoard();

            Console.WriteLine($"dead: {playerRow} {playerCol}");

            Environment.Exit(0);
        }
        private static void Win(int[] previousLocation)
        {
            PrintBoard();

            Console.WriteLine($"won: {previousLocation[0]} {previousLocation[1]}");
            Environment.Exit(0);
        }
        private static bool isPlayerOnTheBoard()
        {
            bool validRow = playerRow >= 0 && playerRow < rows;
            bool validCol = playerCol >= 0 && playerCol < cols;

            if(validRow && validCol)
            {
                return true;
            }
            return false;
        }
        private static void MultiplyBunnies()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if(board[row,col] == 'B')
                    {
                        if(row > 0 && board[row - 1, col] != 'B')
                        {
                            board[row - 1, col] = 'X';
                        }

                        if(row < rows - 1 && board[row + 1, col] != 'B')
                        {
                            board[row + 1, col] = 'X';
                        }

                        if (col > 0 && board[row, col - 1] != 'B')
                        {
                            board[row, col - 1] = 'X';
                        }

                        if (col < cols - 1 && board[row, col + 1] != 'B')
                        {
                            board[row, col + 1] = 'X';
                        }
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if(board[row, col] == 'X')
                    {
                        board[row, col] = 'B';
                    }
                }
            }
        }
        private static void PrintBoard()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(board[row, col]);
                }
                Console.WriteLine();
            }
        }
        private static int[] MovePlayer(char move)
        {
            int[] previousLocation = { playerRow, playerCol };

            switch (move)
            {
                case 'U':
                    playerRow--;
                    break;
                case 'D':
                    playerRow++;
                    break;
                case 'L':
                    playerCol--;
                    break;
                case 'R':
                    playerCol++;
                    break;
            }

            int oldRow = previousLocation[0];
            int oldCol = previousLocation[1];

            if(isPlayerOnTheBoard() && board[playerRow, playerCol] != 'B')
            {
                board[playerRow, playerCol] = 'P';
            }

            board[oldRow, oldCol] = '.';
            return previousLocation;
        }
        private static char[,] ReadAndFillMatrix(int[] dimensions)
        {
            rows = dimensions[0];
            cols = dimensions[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowInput[col];

                    if(rowInput[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            return matrix;
        }
    }
}
