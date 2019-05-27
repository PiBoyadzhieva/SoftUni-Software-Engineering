using System;
using System.Collections.Generic;
using System.Linq;

namespace InternationalSoftUniada24032019
{
    public class Program
    {
        public static void Main()
        {
            var countryContestant = new Dictionary<string, List<string>>();
            var contestantPoints = new Dictionary<string, int>();
            var countryPoints = new Dictionary<string, int>();

            while (true)
            {
                string command = Console.ReadLine();

                if(command == "END")
                {
                    break;
                }

                string[] input = command.Split(" -> ");
                string country = input[0];
                string contestant = input[1];
                int points = int.Parse(input[2]);

                if(!countryContestant.ContainsKey(country))
                {
                    countryContestant[country] = new List<string>();
                }

                List<string> contestantCurrentCountry = countryContestant[country];

                if(!contestantCurrentCountry.Contains(contestant))
                {
                    countryContestant[country].Add(contestant);
                }

                if(!contestantPoints.ContainsKey(contestant))
                {
                    contestantPoints.Add(contestant, points);
                }
                else
                {
                    contestantPoints[contestant] += points;
                }

                if(!countryPoints.ContainsKey(country))
                {
                    countryPoints.Add(country, points);
                }
                else
                {
                    countryPoints[country] += points;
                }
            }

            

            foreach (var kvp in countryPoints.OrderByDescending(x => x.Value))
            {
                string country = kvp.Key;

                Console.WriteLine($"{country}: {kvp.Value}");

                if(countryContestant.ContainsKey(country))
                {
                    List<string> contestant = countryContestant[country];

                    foreach (var person in contestant)
                    {
                        
                        int contestantTotalPoint = contestantPoints[person];
                        Console.WriteLine($"-- {person} -> {contestantTotalPoint}");
                    }

                }

            }
        }
    }
}
