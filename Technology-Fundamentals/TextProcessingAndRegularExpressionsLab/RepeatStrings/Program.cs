using System;
using System.Text;

namespace RepeatStrings
{
    public class Program
    {
        public static void Main()
        {
            string[] array = Console.ReadLine().Split();
            StringBuilder concatWords = new StringBuilder();

            foreach (var word in array)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    concatWords.Append(word);
                }
            }

            Console.WriteLine(concatWords);
        }
    }
}
