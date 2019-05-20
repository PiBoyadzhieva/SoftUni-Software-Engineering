using System;
using System.Linq;

namespace SumMatrixColumns
{
    public class Program
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] array = new int[dimensions[0], dimensions[1]];

            for (int i = 0; i < array.GetLongLength(0); i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = tokens[j];
                }
            }

            for (int col = 0; col < array.GetLength(1); col++)
            {
                int sum = 0;

                for (int row = 0; row < array.GetLength(0); row++)
                {
                    sum += array[row, col];
                }
                Console.WriteLine(sum);
            }

        }
    }
}
