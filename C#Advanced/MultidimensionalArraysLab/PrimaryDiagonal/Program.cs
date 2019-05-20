using System;
using System.Linq;

namespace PrimaryDiagonal
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[,] array = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < n; j++)
                {
                    array[i, j] = tokens[j];
                }
            }

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(i == j)
                    {
                        int number = array[i, j];
                        sum += number;
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
