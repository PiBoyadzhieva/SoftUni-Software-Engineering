using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();

            dict["fragments"] = 0;
            dict["shards"] = 0;
            dict["motes"] = 0;

            var junk = new Dictionary<string, int>();

            while (true)
            {
                bool haveWinner = false;

                var tokens = Console.ReadLine()
                    .ToLower()
                    .Split()
                    .ToArray();

                for (int i = 0; i < tokens.Length; i += 2)
                {
                    string type = tokens[i + 1];
                    int quantity = int.Parse(tokens[i]);


                    if (type == "fragments" || type == "shards" || type == "motes")
                    {
                        if (!dict.ContainsKey(type))
                        {
                            dict.Add(type, quantity);
                        }
                        else
                        {
                            dict[type] += quantity;
                        }
                    }

                    else
                    {
                        if (!junk.ContainsKey(type))
                        {
                            junk.Add(type, quantity);
                        }
                        else
                        {
                            junk[type] += quantity;
                        }
                    }

                    if (dict["motes"] >= 250 || dict["fragments"] >= 250 || dict["shards"] >= 250)
                    {
                        dict[type] = dict[type] - 250;

                        if(type == "shards")
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                        }
                        else if (type == "fragments")
                        {
                            Console.WriteLine("Valanyr obtained!");
                        }
                        else if (type == "motes")
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                        }

                        haveWinner = true;
                        break;
                    }
                }
                if(haveWinner)
                {
                    break;
                }
            }


            foreach (var kvp in dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            foreach (var kvp in junk.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

        }
    }
}
