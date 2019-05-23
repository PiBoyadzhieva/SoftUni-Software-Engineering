using System;

namespace KnightGame
{
    public class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            char[,] board = new char[rows, rows];

            for (int row = 0; row < rows; row++)
            {
                char[] inputRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rows; col++)
                {
                    board[row, col] = inputRow[col];

                }
            }

            int counter = 0;

            while (true)
            {
                int maxCount = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int knightsCount = 0;

                        if (board[row, col] == 'K')
                        {
                            if (isInside(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                            {
                                knightsCount++;
                            }

                            if (isInside(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
                            {
                                knightsCount++;
                            }

                            if (isInside(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                            {
                                knightsCount++;
                            }

                            if (isInside(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
                            {
                                knightsCount++;
                            }

                            if (isInside(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                            {
                                knightsCount++;
                            }

                            if (isInside(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                            {
                                knightsCount++;
                            }

                            if (isInside(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
                            {
                                knightsCount++;
                            }

                            if (isInside(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                            {
                                knightsCount++;
                            }
                        }
                        if (knightsCount > maxCount)
                        {
                            maxCount = knightsCount;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxCount == 0)
                {
                    break;
                }

                board[knightRow, knightCol] = '0';
                counter++;
            }

            Console.WriteLine(counter);
        }

        private static bool isInside(char[,] board, int desiredRow, int desiredCol)
        {
            return desiredRow < board.GetLength(0) && desiredRow >= 0
                && desiredCol < board.GetLength(1) && desiredCol >= 0;
        }
    }
}
