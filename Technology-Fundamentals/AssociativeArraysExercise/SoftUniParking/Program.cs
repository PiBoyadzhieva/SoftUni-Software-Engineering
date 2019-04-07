using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniParking
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> nameLicense = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] tokens = input.Split();
                string name = tokens[1];

                if(tokens[0] == "unregister")
                {
                    if(!nameLicense.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        nameLicense.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                }

                else if(tokens[0] == "register")
                {
                    string license = tokens[2];

                    if(!nameLicense.ContainsKey(name))
                    {
                        nameLicense[name] = license;
                        Console.WriteLine($"{name} registered {license} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {license}");
                    }
                }
            }

            foreach (var kvp in nameLicense)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
