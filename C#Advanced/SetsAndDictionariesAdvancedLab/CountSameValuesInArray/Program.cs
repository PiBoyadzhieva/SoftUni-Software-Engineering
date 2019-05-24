using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    public class Program
    {
        public static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> counter = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if(counter.ContainsKey(number))
                {
                    counter[number]++;
                }
                else
                {
                    counter.Add(number, 1);
                }
            }


            foreach (var item in counter)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
