using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    public class Program
    {
        public static void Main()
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] queue = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new Queue<int>();

            int numbersToEnqueue = input[0];
            int numbersToDequeue = input[1];
            int numberToView = input[2];

            for (int i = 0; i < numbersToEnqueue; i++)
            {
                numbers.Enqueue(queue[i]);
            }

            for (int i = 1; i <= numbersToDequeue; i++)
            {
                numbers.Dequeue();
            }

            if (numbers.Contains(numberToView))
            {
                Console.WriteLine("true");
            }
            else if (numbers.Count > 0)
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
