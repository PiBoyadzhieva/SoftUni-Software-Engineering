using System;

namespace SymbolInMatrix
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] array = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] tokens = Console.ReadLine().ToCharArray();

                for (int j = 0; j < tokens.Length; j++)
                {
                    array[i, j] = tokens[j];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isFound = false;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        isFound = true;
                        break;
                    }
                }
                if(isFound)
                {
                    break;
                }
            }

            if(!isFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
