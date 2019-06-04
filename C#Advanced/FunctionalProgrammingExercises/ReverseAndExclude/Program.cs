using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int divisor = int.Parse(Console.ReadLine());

            numbers.RemoveAll(x => x % int.Parse($"{divisor}") == 0);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
