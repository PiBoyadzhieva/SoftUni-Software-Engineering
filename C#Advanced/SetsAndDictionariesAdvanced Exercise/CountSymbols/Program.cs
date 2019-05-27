using System;
using System.Collections.Generic;

namespace CountSymbols
{
    public class Program
    {
        public static void Main()
        {
            char[] input = Console.ReadLine().ToCharArray();
                
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if(!symbols.ContainsKey(input[i]))
                {
                    symbols.Add(input[i], 0);
                }

                symbols[input[i]]++;
            }

            foreach (var (key, value) in symbols)
            {
                char symbol = key;
                int counter = value;

                Console.WriteLine($"{symbol}: {counter} time/s");
            }
        }
    }
}
