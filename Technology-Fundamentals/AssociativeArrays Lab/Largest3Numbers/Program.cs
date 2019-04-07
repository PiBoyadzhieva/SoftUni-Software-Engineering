using System;
using System.Linq;
using System.Collections.Generic;

namespace Largest3Numbers
{
    public class Program
    {
        public static void Main()
        {
            var list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .Take(3)
                .ToList();

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
