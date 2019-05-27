using System;
using System.Linq;
using System.Collections.Generic;

namespace ExamDemo06042019
{
    public class Program
    {
        public static void Main()
        {
            string[] firstString = Console.ReadLine().Split(" | ");
            string[] secondString = Console.ReadLine().Split(" | ");
            string thirdString = Console.ReadLine();

            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> editedDictionary = new Dictionary<string, List<string>>();

            for (int i = 0; i < firstString.Length; i++)
            {
                string tokens = firstString[i];
                string[] splitedFirstString = tokens.Split(": ");

                string word = splitedFirstString[0];
                string definition = splitedFirstString[1];

                if (!dictionary.ContainsKey(word))
                {
                    dictionary[word] = new List<string>();
                }

                dictionary[word].Add(definition);
            }

            for (int i = 0; i < secondString.Length; i++)
            {
                string word = secondString[i];

                if(!editedDictionary.ContainsKey(word) && dictionary.Keys.Contains(word))
                {
                    editedDictionary[word] = new List<string>();

                    foreach (var kvp in dictionary.Where(x => x.Key == word))
                    {
                          List<string> definition = kvp.Value;

                          foreach (var item in definition)
                          {
                              editedDictionary[word].Add(item);
                          }
                    }
                }
            }

            foreach (var kvp in editedDictionary.OrderBy(x => x.Key))
            {
                List<string> definition = kvp.Value;

                Console.WriteLine($"{kvp.Key}");

                foreach (var item in definition.OrderByDescending(x => x.Length))
                {
                    Console.WriteLine($" -{item}");
                }
            }

            if (thirdString == "End")
            {
                return;
            }
            else
            {
                foreach (var kvp in dictionary.OrderBy(x => x.Key))
                {
                    Console.Write($"{kvp.Key} ");
                }
            }
            Console.WriteLine();

        }
    }
}
