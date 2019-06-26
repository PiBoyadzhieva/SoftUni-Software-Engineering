using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceshipCrafting
{
    public class Program
    {
        public static void Main()
        {
            int[] firstSequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToArray();

            int[] secondSequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> liquids = new Stack<int>(firstSequence);
            Stack<int> items = new Stack<int>(secondSequence);

            int glass = 0;
            int aluminum = 0;
            int lithium = 0;
            int carbon = 0;

            while (liquids.Any() && items.Any())
            {
                int currentLiquids = liquids.Pop();
                int currentItems = items.Pop();

                int sum = currentItems + currentLiquids;


                if (sum == 25)
                {
                    glass++;
                }
                else if(sum == 50)
                {
                    aluminum++;
                }
                else if(sum == 75)
                {
                    lithium++;
                }
                else if(sum == 100)
                {
                    carbon++;
                }
                else
                {
                    currentItems += 3;
                    items.Push(currentItems);
                }
            }

            if (glass > 0 && aluminum > 0 && lithium > 0 && carbon > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }

            if(!liquids.Any())
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }

            if (!items.Any())
            {
                Console.WriteLine("Physical items left: none");
            }
            else
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", items)}");
            }

            Console.WriteLine($"Aluminium: {aluminum}");
            Console.WriteLine($"Carbon fiber: {carbon}");
            Console.WriteLine($"Glass: {glass}");
            Console.WriteLine($"Lithium: {lithium}");
        }
    }
}
