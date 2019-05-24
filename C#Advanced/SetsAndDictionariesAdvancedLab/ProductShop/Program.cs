using System;
using System.Collections.Generic;

namespace ProductShop
{
    public class Program
    {
        public static void Main()
        {
            SortedDictionary<string, Dictionary<string, double>> shops =
                new SortedDictionary<string, Dictionary<string, double>>();

            string[] entry = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            while (entry[0] != "Revision")
            {
                if(!shops.ContainsKey(entry[0]))
                {
                    shops.Add(entry[0], new Dictionary<string, double>());
                }
                if(!shops[entry[0]].ContainsKey(entry[1]))
                {
                    shops[entry[0]].Add(entry[1], 0);
                }

                shops[entry[0]][entry[1]] = double.Parse(entry[2]);

                entry = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}-> ");

                foreach (var item in shop.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}
