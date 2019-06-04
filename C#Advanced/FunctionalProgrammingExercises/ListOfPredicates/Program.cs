using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    public class Program
    {
        public static void Main()
        {
            int upperBound = int.Parse(Console.ReadLine());

            List<int> numbers = Enumerable.Range(1, upperBound).ToList();

            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Distinct()  // removes the same values
                .ToArray();

            for (int i = 0; i < dividers.Length; i++)
            {
                Predicate<int> divisible = (num) => { return num % dividers[i] == 0;  };
                numbers = numbers.FindAll(divisible);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
