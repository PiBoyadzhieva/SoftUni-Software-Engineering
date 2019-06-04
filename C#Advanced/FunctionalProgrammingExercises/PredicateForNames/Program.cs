using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    public class Program
    {
        public static void Main()
        {
            int nameLength = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            Predicate<string> isNameLengthLTE = name => name.Length <= nameLength;

            for (int i = 0; i < names.Count; i++)
            {
                string currentName = names[i];

                if(isNameLengthLTE(currentName))
                {
                    Console.WriteLine(currentName);
                }
            }

        }
    }
}
