using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeASalad
{
    public class Program
    {
        public static void Main()
        {
            string[] vegetable = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            int[] salad = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<string> vegetables = new Stack<string>(vegetable);

            Stack<int> salads = new Stack<int>(salad);

            Stack<int> preparedSalads = new Stack<int>();

            int makedCurrentSalad = 0;

            while (vegetables.Any() && salads.Any())
            {
                string currentVegetable = vegetables.Pop();

                int currentSalads = salads.Pop();

                int calories = 0;

                switch (currentVegetable)
                {
                    case "tomato": calories = 80; break;
                    case "carrot": calories = 136; break;
                    case "lettuce": calories = 109; break;
                    case "potato": calories = 215; break;
                }

                if (calories >= currentSalads)
                {
                    makedCurrentSalad += currentSalads;
                    preparedSalads.Push(makedCurrentSalad);
                    makedCurrentSalad = 0;
                    continue;
                }

                else if (calories < currentSalads)
                {
                    makedCurrentSalad += calories;
                    currentSalads -= calories;
                    salads.Push(currentSalads);
                }

                if(!vegetables.Any() || !salads.Any())
                {
                    makedCurrentSalad += currentSalads;
                    preparedSalads.Push(makedCurrentSalad);
                    salads.Pop();
                }
            }

                Console.WriteLine(string.Join(" ", preparedSalads.Reverse()));

            if(salads.Any())
            {
                
                Console.WriteLine(string.Join(" ", salads));
            }

            if(vegetables.Any())
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
        }
    }
}
