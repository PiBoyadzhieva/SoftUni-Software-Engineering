using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    public class Program
    {
        public static void Main()
        {
            int[] clothes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int capacity = int.Parse(Console.ReadLine());

            Stack<int> stackOfClothes = new Stack<int>(clothes);

            int sum = 0;
            int counter = 1;

            while (stackOfClothes.Count > 0) // || stackOfClothes.Any()
            {
                if (sum + stackOfClothes.Peek() <= capacity)
                {
                    sum += stackOfClothes.Pop();
                }
                else
                {
                    sum = 0;
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
