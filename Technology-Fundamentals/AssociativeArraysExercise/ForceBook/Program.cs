using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, string> nameSide = new Dictionary<string, string>();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "Lumpawaroo")
                {
                    break;
                }

                string[] tokens = new string[0];

                if(input.Contains("|"))
                {
                    tokens = input.Split(" | ");
                    string side = tokens[0];
                    string name = tokens[1];

                    if(!nameSide.ContainsKey(name))
                    {
                        nameSide[name] = side;
                    }
                }
                else
                {
                    tokens = input.Split(" -> ");

                    string name = tokens[0];
                    string side = tokens[1];

                    if (nameSide.ContainsKey(name))
                    {
                        nameSide[name] = side;
                    }
                    else
                    {
                        nameSide[name] = side;
                    }

                    Console.WriteLine($"{name} joins the {side} side!");
                }
            }
            var fillteredNameSide = nameSide
                .GroupBy(x => x.Value)
                .ToDictionary(x => x.Key, x => x.ToDictionary(y => y.Key, y => y.Value))
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key);

            foreach (var kvp in fillteredNameSide)
            {
                string side = kvp.Key;
                Dictionary<string, string> nameSideValue = kvp.Value;

                Console.WriteLine($"Side: {side}, Members: {nameSideValue.Count}");


                foreach (var kvpValue in nameSideValue.OrderBy(x => x.Key))
                {
                    string name = kvpValue.Key;
                    string side2 = kvpValue.Value;

                    Console.WriteLine($"! {name}");
                }
            }
        }
    }
}
