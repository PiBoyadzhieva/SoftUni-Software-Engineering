using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    public class Program
    {
        public static void Main()
        {
            int foodAmount = int.Parse(Console.ReadLine());
            int[] inputOrders = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueOfOrders = new Queue<int>(inputOrders);

            Console.WriteLine(queueOfOrders.Max());

            while (queueOfOrders.Count > 0)
            {
                int currentOrders = queueOfOrders.Peek();

                if (foodAmount < currentOrders)
                {
                    break;
                }

                foodAmount -= queueOfOrders.Dequeue();
            }

            if(queueOfOrders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queueOfOrders)}");
            }
        }
    }
}
