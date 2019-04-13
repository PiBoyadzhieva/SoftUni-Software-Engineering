using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _10012019SantasSecretHelper
{
    public class Program
    {
        public static void Main()
        {
            int key = int.Parse(Console.ReadLine());
            var children = new List<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "end")
                {
                    break;
                }

                string message = string.Empty;

                for (int i = 0; i < input.Length; i++)
                {
                    char currentChar = input[i];
                    message += (char)(currentChar - key);
                }

                string pattern = @"@(?<name>[A-Za-z]+)[^-@!:>]*!(?<behavior>(G))!";

                Match match = Regex.Match(message, pattern);
                string name = string.Empty;

                if(match.Success)
                {
                    name = match.Groups["name"].Value;
                    children.Add(name);
                }
            }

            foreach (var name in children)
            {
                Console.WriteLine(name);
            }
        }
    }
}
