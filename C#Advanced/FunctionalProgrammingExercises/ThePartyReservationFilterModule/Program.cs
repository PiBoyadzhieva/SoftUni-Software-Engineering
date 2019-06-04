using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    public class Program
    {
        public static void Main()
        {
            string[] names = Console.ReadLine()
                .Split();

            string filter = Console.ReadLine();

            List<string> filters = new List<string>();

            while (filter != "Print")
            {
                string[] filterInfo = filter.Split(";");

                string action = filterInfo[0];

                if(action == "Add filter")
                {
                    filters.Add($"{filterInfo[1]};{filterInfo[2]}");
                }
                else if (action == "Remove filter")
                {
                    filters.Remove($"{filterInfo[1]};{filterInfo[2]}");
                }

                filter = Console.ReadLine();
            }

            Func<string, int, bool> lengthFilter = (name, length) => name.Length == length;
            Func<string, string, bool> startsWithFilter = (name, param) => name.StartsWith(param);
            Func<string, string, bool> endsWithFilter = (name, param) => name.EndsWith(param);
            Func<string, string, bool> containsFilter = (name, param) => name.Contains(param);


            foreach (var currentFilter in filters)
            {
                string[] currentFilterInfo = currentFilter.Split(";");

                string action = currentFilterInfo[0];
                string parameter = currentFilterInfo[1];

                if(action == "Starts with")
                {
                    names = names.Where(name => !startsWithFilter(name, parameter)).ToArray();
                }
                else if (action == "Ends with")
                {
                    names = names.Where(name => !endsWithFilter(name, parameter)).ToArray();
                }
                else if (action == "Length")
                {
                    names = names.Where(name => !lengthFilter(name, int.Parse(parameter))).ToArray();
                }
                else if (action == "Contains")
                {
                    names = names.Where(name => !containsFilter(name, parameter)).ToArray();
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
}
