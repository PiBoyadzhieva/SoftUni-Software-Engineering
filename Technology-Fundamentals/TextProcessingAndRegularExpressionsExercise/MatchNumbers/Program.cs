using System;
using System.Text.RegularExpressions;

namespace MatchNumbers
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = $"(^|(?<=\\s))-?\\d+(\\.\\d+)?($|(?=\\s))";

            MatchCollection numbers = Regex.Matches(input, pattern);

            foreach (Match number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}
