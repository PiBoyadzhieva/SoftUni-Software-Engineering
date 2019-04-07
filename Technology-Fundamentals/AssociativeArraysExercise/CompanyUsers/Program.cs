using System;
using System.Linq;
using System.Collections.Generic;

namespace CompanyUsers
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> companyID = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "End")
                {
                    break;
                }

                string[] tokens = input.Split(" -> ");

                string company = tokens[0];
                string id = tokens[1];

                if(!companyID.ContainsKey(company))
                {
                    companyID.Add(company, new List<string>());
                    companyID[company].Add(id);
                }

                if (!companyID[company].Contains(id))
                {
                    if(!companyID[company].Contains(id))
                    {
                        companyID[company].Add(id);
                    }
                }
            }

            foreach (var kvp in companyID.OrderBy(x => x.Key))
            {
                List<string> employees = kvp.Value;

                Console.WriteLine($"{kvp.Key}");

                foreach (var id in employees)
                {
                    Console.WriteLine($"-- {id}");
                }
            }

        }
    }
}
