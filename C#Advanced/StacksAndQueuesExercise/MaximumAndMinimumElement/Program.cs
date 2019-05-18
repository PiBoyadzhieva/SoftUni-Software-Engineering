using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    public class Program
    {
        public static void Main()
        {
            Stack<int> stackOfNumber = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input.Length > 1)
                {
                    int element = input
                                .Split()
                                .Select(int.Parse)
                                .ToArray()[1];

                    stackOfNumber.Push(element);
                }

                else if (input == "2" && stackOfNumber.Count > 0)
                {
                    stackOfNumber.Pop();
                }

                else if (input == "3" && stackOfNumber.Count > 0)
                {
                    Console.WriteLine(stackOfNumber.Max());
                }

                else if (input == "4" && stackOfNumber.Count > 0)
                {
                    Console.WriteLine(stackOfNumber.Min());
                }
            }

            Console.WriteLine(string.Join(", ", stackOfNumber));
        }
    }
}
