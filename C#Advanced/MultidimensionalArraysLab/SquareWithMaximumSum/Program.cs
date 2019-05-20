using System;
using System.Linq;

namespace SquareWithMaximumSum
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
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = tokens[j];
                }
            }

            int maxSum = int.MinValue;
            int selectedRow = -1;
            int selectedCol = -1;

            for (int row = 0; row < array.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < array.GetLength(1) - 1; col++)
                {
                    int sum = array[row, col] + array[row, col + 1] + array[row + 1, col] + array[row + 1, col + 1];

                    if(sum > maxSum)
                    {
                        maxSum = sum;
                        selectedRow = row;
                        selectedCol = col;
                    }
                }
            }

            Console.WriteLine($"{array[selectedRow, selectedCol]} {array[selectedRow, selectedCol + 1]}\n" +
                $"{array[selectedRow +1, selectedCol]} {array[selectedRow + 1, selectedCol + 1]}\n" +
                $"{maxSum}");
            
        }
    }
}
