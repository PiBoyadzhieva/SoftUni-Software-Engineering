using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    public class Program
    {
        public static void Main()
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToArray();

            int[] bottlesFilled = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> cups = new Stack<int>(cupsCapacity);
            Stack<int> bottles = new Stack<int>(bottlesFilled);

            int wasted = 0;

            while(cups.Any() && bottles.Any())
            {
                int cup = cups.Pop();
                int bottle = bottles.Pop();

                if(bottle == cup)
                {
                    continue;
                }
                else if(bottle > cup)
                {
                    bottle -= cup;
                    wasted += bottle;
                }
                else if(bottle < cup)
                {
                    cup -= bottle;
                    cups.Push(cup);
                }
            }

            if(bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles.Reverse())}");
            }
            else if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wasted}");
        }
    }
}
