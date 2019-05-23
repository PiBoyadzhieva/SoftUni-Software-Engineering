using System;
using System.Linq;

namespace MatrixShuffling
{
    public class Program
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string[][] matrix = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new string[cols];
                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if(tokens[0] != "swap" || tokens.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                int x1 = int.Parse(tokens[1]);
                int y1 = int.Parse(tokens[2]);
                int x2 = int.Parse(tokens[3]);
                int y2 = int.Parse(tokens[4]);

                if(x1 < 0 || x1 >= rows ||
                   y1 < 0 || y1 >= cols ||
                   x2 < 0 || x2 >= rows ||
                   y2 < 0 || y2 >= cols)
                {
                    Console.WriteLine("Invalid input!");
                    input = Console.ReadLine();
                    continue;
                }

                string firstElement = matrix[x1][y1];
                string secondElement = matrix[x2][y2];

                matrix[x1][y1] = secondElement;
                matrix[x2][y2] = firstElement;

                Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(row => String.Join(" ", row))));

                input = Console.ReadLine();

            }
        }
    }
}
