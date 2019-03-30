using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MatchPhoneNumber
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string numbers = Console.ReadLine();
            string regex = @"(?<!\d)[+]359([ -])2\1\d{3}\1\d{4}\b";

            List<string> phones = new List<string>();
            MatchCollection matched = Regex.Matches(numbers, regex);

            foreach (Match number in matched)
            {
                phones.Add(number.Value);
            }

            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
