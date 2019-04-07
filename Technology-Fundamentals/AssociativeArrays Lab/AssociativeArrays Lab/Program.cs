using System;
using System.Linq;
using System.Collections.Generic;

namespace AssociativeArrays_Lab
{
    public class Program
    {
        public static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            var count = new SortedDictionary<double, int>();
            //count.

            foreach (var number in numbers)
            {
                if(!count.ContainsKey(number))
                {
                    count[number] = 0;
                }

                    count[number]++;
            }

            foreach (var kvp in count)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
