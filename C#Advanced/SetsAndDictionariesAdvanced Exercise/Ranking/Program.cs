using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, string> contest = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> submissions = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] tokens = input.Split(":");
                string contestName = tokens[0];
                string password = tokens[1];

                if(!contest.ContainsKey(contestName))
                {
                    contest.Add(contestName, password);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] tokens = input.Split("=>");

                string contestName = tokens[0];
                string contestPassword = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (!contest.ContainsKey(contestName) || contest[contestName] != contestPassword)
                {
                    input = Console.ReadLine();
                    continue;
                }

                if(!submissions.ContainsKey(username))
                {
                    submissions.Add(username, new Dictionary<string, int>());
                }
                if(!submissions[username].ContainsKey(contestName))
                {
                    submissions[username].Add(contestName, 0);
                }
                if(submissions[username][contestName] < points)
                {
                    submissions[username][contestName] = points;
                }

                input = Console.ReadLine();
            }

            var bestCandidates = submissions
                .OrderByDescending(v => v.Value.Values.Sum(x => x))
                .FirstOrDefault();

            string bestCandidatesName = bestCandidates.Key;
            int topPoints = bestCandidates.Value.Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidatesName} with total {topPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var (key, value) in submissions.OrderBy(x => x.Key))
            {
                Console.WriteLine(key);

                foreach (var (contestName, points) in value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contestName} -> {points}");
                }
            }

        }
    }
}
