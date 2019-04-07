using System;
using System.Linq;
using System.Collections.Generic;

namespace WordFilter
{
    public class Program
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split()
                .Where(x => x.Length % 2 == 0)
                .ToList()
                .ForEach(x => Console.WriteLine(x));

        }
    }
}
