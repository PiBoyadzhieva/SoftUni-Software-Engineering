using System;
using System.Linq;
using System.Collections.Generic;

namespace CountCharsInAStrisng
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char[] text = Console.ReadLine()
                .Where(x => x != ' ').ToArray();

            var dictionary = new Dictionary<char, int>();

            foreach (var character in text)
            {
                if (!dictionary.ContainsKey(character))
                {
                    dictionary[character] = 0;
                }

                dictionary[character]++;
            }

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
