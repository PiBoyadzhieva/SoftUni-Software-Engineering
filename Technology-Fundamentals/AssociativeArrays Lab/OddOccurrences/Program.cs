using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace OddOccurrences
{
    public class Program
    {
        public static void Main()
        {
            string[] words = Console.ReadLine()
                .Split();

            var counts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string wordInLowerCase = word.ToLower();

                if(counts.ContainsKey(wordInLowerCase))
                {
                    counts[wordInLowerCase]++;
                }
                else
                {
                    counts.Add(wordInLowerCase, 1);
                }
            }

            foreach (var kvp in counts)
            {
                if(kvp.Value % 2 != 0)
                {
                    Console.Write(kvp.Key + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
