using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggerColection
                = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                if(input.Contains("joined"))
                {
                    string username = input.Split()[0];

                    if(!vloggerColection.ContainsKey(username))
                    {
                        vloggerColection.Add(username, new Dictionary<string, HashSet<string>>());
                        vloggerColection[username].Add("followings", new HashSet<string>());
                        vloggerColection[username].Add("followers", new HashSet<string>());

                    }
                }
                else if(input.Contains("followed"))
                {
                    string[] usernames = input.Split();
                    string follower = usernames[0];
                    string followed = usernames[2];

                    if(!vloggerColection.ContainsKey(follower) || !vloggerColection.ContainsKey(followed) || follower == followed)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    vloggerColection[follower]["followings"].Add(followed);
                    vloggerColection[followed]["followers"].Add(follower);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggerColection.Count} vloggers in its logs.");

            int count = 1;

            var sortedVloggers = vloggerColection
                .OrderByDescending(f => f.Value["followers"].Count)
                .ThenBy(f => f.Value["followings"].Count)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var (username, value) in sortedVloggers)
            {
                int followersCount = sortedVloggers[username]["followers"].Count;
                int followingsCount = sortedVloggers[username]["followings"].Count;

                Console.WriteLine($"{count}. {username} : {followersCount} followers, {followingsCount} following");

                if(count == 1)
                {
                    var followersCollection = value["followers"].OrderBy(x => x).ToList();

                    foreach (var currentUsername in followersCollection)
                    {
                        Console.WriteLine($"*  {currentUsername}");
                    }
                }

                count++;
            }
        }
    }
}
