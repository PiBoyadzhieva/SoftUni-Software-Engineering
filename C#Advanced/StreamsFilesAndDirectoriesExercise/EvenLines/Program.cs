using System;
using System.IO;
using System.Linq;

namespace EvenLines
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string textFilePath = @"text.txt";
            int counter = 0;

            using (StreamReader streamReader = new StreamReader(textFilePath))
            {
                while (true)
                {
                    string currentLine = streamReader.ReadLine();

                    if(currentLine == null)
                    {
                        break;
                    }

                    if(counter % 2 == 0)
                    {
                        string replacedSymbols = ReplaceSpecialCharacters(currentLine);
                        string reversedWords = ReverseWords(replacedSymbols);

                        Console.WriteLine(reversedWords);
                    }

                    counter++;
                }
            }
        }

        private static string ReverseWords(string replacedSymbols)
        {
            return string.Join(" ", replacedSymbols.Split().Reverse());
        }

        private static string ReplaceSpecialCharacters(string currentLine)
        {
            return currentLine.Replace("-", "@")
                .Replace(",", "@")
                .Replace(".", "@")
                .Replace("!", "@")
                .Replace("!?", "@");
        }
    }
}
