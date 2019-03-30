using System;

namespace Substring
{
    public class Program
    {
        public static void Main()
        {
            string word = Console.ReadLine().ToLower();
            string text = Console.ReadLine().ToLower();

            while (true)
            {
                var nextIndexOfWprd = text.IndexOf(word);

                if(nextIndexOfWprd == -1)
                {
                    break;
                }

                text = text.Replace(word, String.Empty);
            }

            Console.WriteLine(text);
        }
    }
}
