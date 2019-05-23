using System;
using System.Linq;

namespace DiagonalDifference
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] inputLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }

            int sumPrimaryDiag = 0;
            int sumSecondDiag = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row == col)
                    {
                        sumPrimaryDiag += matrix[row, col];
                    }

                    if(n - 1 - row == col)
                    {
                        sumSecondDiag += matrix[row, col];
                    }

                }
            }

            int diff = Math.Abs(sumPrimaryDiag - sumSecondDiag);

            Console.WriteLine(diff);
        }
    }
}
