using System;
using System.Collections.Generic;
using System.Linq;

namespace _10012019SantasNewList
{
    public class Program
    {
        public static void Main()
        {
            var namePoints = new Dictionary<string, int>();
            var typeCounts = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "END")
                {
                    break;
                }

                string[] tokens = input.Split("->");

                if (tokens[0] == "Remove")
                {
                    string childName = tokens[1];
                    namePoints.Remove(childName);
                }

                else
                {
                    string childName = tokens[0];
                    string typeOfPresent = tokens[1];
                    int amount = int.Parse(tokens[2]);

                    if (!namePoints.ContainsKey(childName))
                    {
                        namePoints[childName] = amount;
                    }
                    else
                    {
                        namePoints[childName] += amount;
                    }

                    if (!typeCounts.ContainsKey(typeOfPresent))
                    {
                        typeCounts[typeOfPresent] = amount;
                    }
                    else
                    {
                        typeCounts[typeOfPresent] += amount;
                    }
                }
            }

            Console.WriteLine("Children:");

            foreach (var kvp in namePoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            Console.WriteLine("Presents:");

            foreach (var kvp in typeCounts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
