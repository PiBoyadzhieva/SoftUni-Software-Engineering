using System;
using System.Text.RegularExpressions;

namespace Deciphering
{
    public class Program
    {
        public static void Main()
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();
            string newString = string.Empty;

            for (int i = 0; i < firstString.Length; i++)
            {
                char currentChar = (char)(firstString[i] - 3);
                newString += currentChar;
            }

            //Console.WriteLine(newString);
            for (int i = 0; i < newString.Length; i++)
            {
                bool isCorect = (newString[i] >= 97 && newString[i] <= 125) || newString[i] == '#' || newString[i] == ' ';

                if (isCorect == false)
                {
                    Console.WriteLine($"This is not the book you are looking for.");
                    return;
                }

            }

            for (int i = 0; i < newString.Length; i++)
            {
                string[] splitedSecondString = secondString.Split(" ");
                string firstSubstring = splitedSecondString[0];
                string secondSubstring = splitedSecondString[1];

                if (newString.Contains(firstSubstring))
                {
                    newString = newString.Replace(firstSubstring, secondSubstring);
                }
            }

            Console.WriteLine(newString);
        }
    }
}
