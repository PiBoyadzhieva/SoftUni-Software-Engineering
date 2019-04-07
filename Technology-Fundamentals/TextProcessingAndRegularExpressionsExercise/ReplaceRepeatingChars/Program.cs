using System;

namespace ReplaceRepeatingChars
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length-1; i++)
            {
                char currentChar = input[i];
                char nextChar = input[i + 1];

                if (currentChar == nextChar)
                {
                    input = input.Remove(i, 1);
                    i--;
                }
            }
            Console.WriteLine(input);
        }
    }
}
