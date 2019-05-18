using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] stack = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> numbers = new Stack<int>();

            int numbersToPush = input[0];
            int numbersToPop = input[1];
            int view = input[2];

            for (int i = 0; i < numbersToPush; i++)
            {
                numbers.Push(stack[i]);
            }

            for (int i = 1; i <= numbersToPop; i++)
            {
                numbers.Pop();
            }

            if (numbers.Contains(view))
            {
                Console.WriteLine("true");
            }
            else if(numbers.Count > 0)
            {
                Console.WriteLine(numbers.Min());
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
