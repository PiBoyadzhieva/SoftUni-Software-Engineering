using System;
using System.Linq;

namespace SumNumbers
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(Parse)
                .ToArray();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }

        public static Func<string, int> Parse = x => int.Parse(x);
    }
}
