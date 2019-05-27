using System;
using System.Collections.Generic;

namespace Wardrobe
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ");

                string color = input[0];

                string[] tokens = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < tokens.Length; j++)
                {
                    string item = tokens[j];

                    if(!clothes.ContainsKey(color))
                    {
                        clothes.Add(color, new Dictionary<string, int>());
                    }
                    if(!clothes[color].ContainsKey(item))
                    {
                        clothes[color].Add(item, 0);
                    }

                    clothes[color][item]++;
                }
            }

            string[] itemToFound = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var (key, value) in clothes)
            {
                string color = key;
                Dictionary<string, int> items = value;

                Console.WriteLine($"{color} clothes: ");

                foreach (var (item, counter) in items)
                {
                    if(item == itemToFound[1] && color == itemToFound[0])
                    {
                        Console.WriteLine($"* {item} - {counter} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item} - {counter}");
                    }
                }
            }
        }
    }
}
