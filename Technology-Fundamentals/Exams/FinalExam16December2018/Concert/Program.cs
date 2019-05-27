using System;
using System.Collections.Generic;
using System.Linq;

namespace Concert
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> bandsAndMembers = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandTime = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "start of concert")
                {
                    break;
                }

                string[] command = input.Split("; ");
                string bandName = command[1];

                if (command[0] == "Add")
                {
                    List<String> members = command[2].Split(", ").ToList();

                    if (!bandsAndMembers.ContainsKey(bandName))
                    {
                        bandsAndMembers[bandName] = new List<string>();
                    }

                    foreach (var member in members)
                    {
                        if (!bandsAndMembers[bandName].Contains(member))
                        {
                            bandsAndMembers[bandName].Add(member);
                        }
                    }
                }

                if(command[0] == "Play")
                {
                    int time = int.Parse(command[2]);

                    if (!bandsAndMembers.ContainsKey(bandName))
                    {
                        bandsAndMembers[bandName] = new List<string>();
                    }

                    if (!bandTime.ContainsKey(bandName))
                    {
                        bandTime.Add(bandName, time);
                    }
                    else
                    {
                        bandTime[bandName] += time;
                    }
                }
            }

            Console.WriteLine($"Total time: {bandTime.Values.Sum()}");

            foreach (var kvp in bandTime.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }


            string finalBand = Console.ReadLine();

            foreach (var kvp in bandsAndMembers)
            {
                if (finalBand == kvp.Key)
                {
                    Console.WriteLine($"{kvp.Key}");

                    foreach (var member in kvp.Value)
                    {
                        Console.WriteLine($"=> {member}");
                    }
                }
            }
        }
    }
}
