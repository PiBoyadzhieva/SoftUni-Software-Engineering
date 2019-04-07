using System;
using System.Collections.Generic;
using System.Linq;

namespace AMinerTask
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, int> sequence = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                {
                    break;
                }

                int quantity = int.Parse(Console.ReadLine());

                if (!sequence.ContainsKey(input))
                {
                    sequence[input] = quantity;
                }

                else
                {
                    sequence[input] += quantity;
                }
            }

            foreach (var kvp in sequence)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
