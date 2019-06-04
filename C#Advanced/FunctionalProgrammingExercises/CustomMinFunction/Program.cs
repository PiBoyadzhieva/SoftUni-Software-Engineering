using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction
{
    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                //.OrderBy(x => x)
                .ToList();

            //Func<List<int>, int> minNumber = x => x.FirstOrDefault();
            Func<List<int>, int> minNumber = x => x.Min();

            //Console.WriteLine(minNumber(numbers));

            Action<int> print = x => Console.WriteLine(x);

            print(minNumber(numbers));
        }
    }
}
