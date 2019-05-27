using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmojiSumator24032019
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<int> emojiCode = Console.ReadLine().Split(":").Select(int.Parse).ToList();

            bool isEqual = false;
            List<string> emoji = new List<string>();
            int totalPower = 0;

            string pattern = @"(?<= )[:][a-z]{4,}[:](?=[ ,.!?])";

            MatchCollection matched = Regex.Matches(input, pattern);

            foreach (Match item in matched)
            {
                emoji.Add(item.ToString());
            }

            for (int i = 0; i < emoji.Count; i++)
            {
                string currentEmoji = emoji[i];
                List<int> emojiSum = new List<int>();

                for (int j = 0; j < currentEmoji.Length; j++)
                {
                    int curentChar = currentEmoji[j];
                    int currentSum = 0;

                    if(curentChar == ':')
                    {
                        continue;
                    }

                    currentSum += curentChar;
                    emojiSum.Add(currentSum);
                    //totalPower += curentChar;
                }

                totalPower += emojiSum.Sum();
                if (emojiSum.SequenceEqual(emojiCode))
                {
                    isEqual = true;
                }
            }

            if(isEqual)
            {
                totalPower *= 2;
            }

            if(emoji.Count == 0)
            {
                Console.WriteLine($"Total Emoji Power: 0");
            }
            else
            {
                Console.WriteLine($"Emojis found: {string.Join(", ", emoji)}");
                Console.WriteLine($"Total Emoji Power: {totalPower}");
            }
        }
    }
}
