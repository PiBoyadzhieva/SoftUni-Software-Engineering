using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();

                int counter = 0;
                string encryptedMessages = string.Empty;

                for (int j = 0; j < message.Length; j++)
                {
                    char currentChar = message[j];

                    if (currentChar == 's' || currentChar == 't' || currentChar == 'a' || currentChar == 'r'
                        || currentChar == 'S' || currentChar == 'T' || currentChar == 'A' || currentChar == 'R')
                    {
                        counter++;
                    }
                }

                for (int j = 0; j < message.Length; j++)
                {
                    char character = (char)(message[j] - counter);
                    encryptedMessages += character.ToString();
                }


                string pattern = $"@(?<name>[A-Za-z]+)([^@:!\\->]*):(?<population>[0-9]+)([^@:!\\->]*)!(?<type>(A|D))!([^@:!\\->]*)->(?<count>[0-9]+)";

                Match match = Regex.Match(encryptedMessages, pattern);

                if(match.Success)
                {
                    string name = match.Groups["name"].Value;
                    var type = match.Groups["type"].Value;

                    if (type == "A")
                    {
                        attackedPlanets.Add(name);
                    }
                    else
                    {
                        destroyedPlanets.Add(name);
                    }
                }
            }

            int sumAttacked = attackedPlanets.Count;
            int sumDestroyed = destroyedPlanets.Count;

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var planet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var planet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }

        }
    }
}
