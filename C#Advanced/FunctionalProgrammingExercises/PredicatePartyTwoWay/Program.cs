using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    public class Program
    {
        public static void Main()
        {
            List<string> guests = Console.ReadLine()
                .Split()
                .ToList();

            string input = Console.ReadLine();

            while (input != "Party!")
            {
                string[] tokens = input.Split();

                string command = tokens[0];
                string filterCommand = tokens[1];
                string criteria = tokens[2];

                if (command == "Remove")
                {
                    //List<string> guestsToRemove = new List<string>();

                    if (filterCommand == "StartsWith")
                    {
                        guests.RemoveAll(x => x.StartsWith(criteria));
                    }
                    else if (filterCommand == "EndsWith")
                    {
                        guests.RemoveAll(x => x.EndsWith(criteria));
                    }
                    else if (filterCommand == "Length")
                    {
                        guests.RemoveAll(x => x.Length == int.Parse(criteria));
                    }
                }

                else if (command == "Double")
                {
                    List<string> guestsToAdd = new List<string>();

                    if (filterCommand == "StartsWith")
                    {
                        guestsToAdd = guests.Where(x => x.StartsWith(criteria)).ToList();
                    }
                    else if (filterCommand == "EndsWith")
                    {
                        guestsToAdd = guests.Where(x => x.EndsWith(criteria)).ToList();
                    }
                    else if (filterCommand == "Length")
                    {
                        guestsToAdd = guests.Where(x => x.Length == int.Parse(criteria)).ToList();
                    }

                    foreach (var name in guestsToAdd)
                    {
                        int index = guests.IndexOf(name);

                        guests.Insert(index, name);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine
                (guests.Any() ? $"{string.Join(", ", guests)} are going to the party!"
                : "Nobody is going to the party!");
        }
    }
}
