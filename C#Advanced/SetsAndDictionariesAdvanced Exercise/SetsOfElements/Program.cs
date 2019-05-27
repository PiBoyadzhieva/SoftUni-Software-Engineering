using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            HashSet<double> firstSet = new HashSet<double>();
            HashSet<double> secondSet = new HashSet<double>();

            for (int i = 0; i < numbers[0]; i++)
            {
                double input = double.Parse(Console.ReadLine());

                firstSet.Add(input);
            }

            for (int i = 0; i < numbers[1]; i++)
            {
                double input = double.Parse(Console.ReadLine());

                secondSet.Add(input);
            }

            HashSet<double> result = new HashSet<double>();

            foreach (var item in firstSet)
            {
                if(secondSet.Contains(item))
                {
                    result.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
