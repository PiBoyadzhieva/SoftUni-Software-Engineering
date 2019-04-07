using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace WordSynonyms
{
    public class Program
    {
        public static void Main()
        {
            int totalWords = int.Parse(Console.ReadLine());

            var words = new Dictionary<string, List<string>>();

            for (int i = 0; i < totalWords; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!words.ContainsKey(word))
                {
                    words[word] = new List<string>();
                }

                words[word].Add(synonym);
            }

            foreach (var kvp in words)
            {
                string word = kvp.Key;
                List<string> synonym = kvp.Value;

                Console.WriteLine($"{word} - {string.Join(", ", synonym)}");
            }
        }
    }
}
