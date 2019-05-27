using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            SortedSet<string> periodicTable = new SortedSet<string>();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < input.Length; j++)
                {
                    periodicTable.Add(input[j]);
                }
                    
            }

            Console.WriteLine(string.Join(" ", periodicTable));
        }
    }
}
