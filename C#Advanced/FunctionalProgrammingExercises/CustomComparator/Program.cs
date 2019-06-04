using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComparator
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();


            Func<int, int, int> sortFunc = (a, b) => a.CompareTo(b);
            Action<int[], int[]> print = (x, y) => Console.WriteLine($"{string.Join(" ", x)} {string.Join(" ", y)}");

            int[] evenNumbers = numbers.Where(x => x % 2 == 0).OrderBy(n => n).ToArray();
            int[] oddNumbers = numbers.Where(x => x % 2 != 0).OrderBy(n => n).ToArray();

            Array.Sort(evenNumbers, new Comparison<int>(sortFunc));
            Array.Sort(oddNumbers, new Comparison<int>(sortFunc));

            print(evenNumbers, oddNumbers);
        }
    }
}
