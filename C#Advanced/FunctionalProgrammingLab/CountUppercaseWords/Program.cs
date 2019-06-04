using System;
using System.Linq;

namespace CountUppercaseWords
{
    public class Program
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => char.IsUpper(x[0]))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
