using System;
using System.Collections.Generic;
using System.Linq;

namespace TrojanInvasion
{
    public class Program
    {
        public static void Main()
        {
            int numberOfWaves = int.Parse(Console.ReadLine());

            List<int> platesOfTheSpartan = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Stack<int> troyansStack = new Stack<int>();

            for (int i = 1; i <= numberOfWaves; i++)
            {
                List<int> warriorsList = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                foreach (var war in warriorsList)
                {
                    troyansStack.Push(war);
                }

                if (i % 3 == 0)
                {
                    int additionalPlate = int.Parse(Console.ReadLine());
                    platesOfTheSpartan.Add(additionalPlate);
                }

                while (platesOfTheSpartan.Any() && troyansStack.Any())
                {
                    int currentTroyan = troyansStack.Pop();
                    int currentPlate = platesOfTheSpartan[0];

                    if (currentTroyan > currentPlate)
                    {
                        currentTroyan -= currentPlate;
                        troyansStack.Push(currentTroyan);
                        platesOfTheSpartan.RemoveAt(0);
                    }

                    else if (currentTroyan < currentPlate)
                    {
                        currentPlate -= currentTroyan;
                        platesOfTheSpartan[0] = currentPlate;
                    }

                    else if (currentTroyan == currentPlate)
                    {
                        platesOfTheSpartan.RemoveAt(0);
                    }
                }

                if (platesOfTheSpartan.Count == 0)
                {
                    break;
                }
            }

            if (platesOfTheSpartan.Count == 0)
            {
                Console.WriteLine($"The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", troyansStack)}");
            }
            else
            {
                Console.WriteLine($"The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", platesOfTheSpartan)}");
            }
        }
    }
}
