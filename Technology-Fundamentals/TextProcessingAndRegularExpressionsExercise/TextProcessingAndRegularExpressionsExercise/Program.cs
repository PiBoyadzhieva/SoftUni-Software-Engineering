using System;
using System.Linq;

namespace TextProcessingAndRegularExpressionsExercise
{
    public class Program
    {
        public static void Main()
        {
            string[] words = Console.ReadLine()
                .Split(", ")
                .ToArray();

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                bool isValid = false;

                if(word.Length >= 3 && word.Length <= 16)
                {
                    for (int j = 0; j < word.Length; j++)
                    {
                        char currentChar = word[j];

                        if(char.IsLetterOrDigit(currentChar) || currentChar == '_' || currentChar == '-')
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if(isValid)
                    {
                        Console.WriteLine(word);
                    }
                }
            }
        }
    }
}
