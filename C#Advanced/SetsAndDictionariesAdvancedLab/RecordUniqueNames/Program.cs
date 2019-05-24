using System;
using System.Collections.Generic;

namespace RecordUniqueNames
{
    public class Program
    {
        public static void Main()
        {
            int namesCount = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < namesCount; i++)
            {
                string name = Console.ReadLine();

                names.Add(name);
            }

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
        }
    }
}
