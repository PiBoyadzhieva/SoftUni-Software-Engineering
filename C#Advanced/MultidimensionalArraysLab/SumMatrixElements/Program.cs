using System;
using System.Linq;

namespace SumMatrixElements
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
            int sum = 0;

            for (int i = 0; i < array.GetLongLength(0); i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = tokens[j];
                    sum += tokens[j];
                }
            }

            Console.WriteLine(array.GetLength(0));
            Console.WriteLine(array.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
