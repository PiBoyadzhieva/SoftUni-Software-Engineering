using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniExamResults
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, int> namePoints = new Dictionary<string, int>();
            Dictionary<string, int> languageCount = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "exam finished")
                {
                    break;
                }

                string[] tokens = input.Split("-");

                string name = tokens[0];
                string language = tokens[1];

                if (tokens.Length == 2)
                {
                    namePoints.Remove(name);
                    continue;
                }

                int points = int.Parse(tokens[2]);

                if(!namePoints.ContainsKey(name))
                {
                    namePoints[name] = points;
                }

                else
                {
                    if(points > namePoints[name])
                    {
                        namePoints[name] = points;
                    }
                }

                if(!languageCount.ContainsKey(language))
                {
                    languageCount[language] = 1;
                }
                else
                {
                    languageCount[language]++;
                }
            }

            Console.WriteLine("Results:");
            Console.WriteLine(string.Join(Environment.NewLine, 
                namePoints
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(x => $"{x.Key} | {x.Value}")));

            Console.WriteLine("Submissions:");
            Console.WriteLine(string.Join(Environment.NewLine,
                languageCount
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Select(x => $"{x.Key} - {x.Value}")));
        }
    }
}
