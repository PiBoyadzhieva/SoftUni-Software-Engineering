using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    public class Program
    {
        public static void Main()
        {
            int numberOfRecord = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continents =
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < numberOfRecord; i++)
            {
                string[] entry = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (!continents.ContainsKey(entry[0]))
                {
                    continents.Add(entry[0], new Dictionary<string, List<string>>());
                }
                if (!continents[entry[0]].ContainsKey(entry[1]))
                {
                    continents[entry[0]].Add(entry[1], new List<string>());
                }

                continents[entry[0]][entry[1]].Add(entry[2]);
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}: ");

                foreach (var item in continent.Value)
                {
                    Console.WriteLine($"    {item.Key} -> {string.Join(", ", item.Value)}");
                }
            }

        }
    }
}
