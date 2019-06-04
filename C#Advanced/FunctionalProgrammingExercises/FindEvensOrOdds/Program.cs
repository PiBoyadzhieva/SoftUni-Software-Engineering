using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    public class Program
    {
        public static void Main()
        {
            int[] range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int start = range[0];
            int end = range[1];

            string typeNumbers = Console.ReadLine();

            List<int> numbers = new List<int>();

            //Predicate<int> filter = x => typeNumbers == "odd" ? x % 2 != 0 : x % 2 == 0;
            Func<int, bool> filterFunc = x => typeNumbers == "odd" ? x % 2 != 0 : x % 2 == 0;

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            //Console.WriteLine(string.Join(" ", numbers.Where(x => filter(x))));
            Console.WriteLine(string.Join(" ", numbers.Where(filterFunc)));
        }
    }
}
