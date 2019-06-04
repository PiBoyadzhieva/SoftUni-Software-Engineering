using System;
using System.Collections.Generic;
using System.Linq;

namespace ActionPrint
{
    public class Program
    {
        public static void Main()
        {
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<string, string> format = x => $"Sir {x}";
            Action<List<string>> print = x => Console.WriteLine(string
                .Join(Environment.NewLine, x.Select(format)));

            //Action<List<string>> print = x => Console.WriteLine("Sir " + string
            //    .Join(Environment.NewLine + "Sir ", names));

            print(names);
        }
    }
}
