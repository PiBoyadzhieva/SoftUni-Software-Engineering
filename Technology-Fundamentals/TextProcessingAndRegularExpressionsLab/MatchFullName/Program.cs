using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string regex = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            MatchCollection matched = Regex.Matches(input, regex);

            foreach (Match match in matched)
            {
                Console.Write(match + " ");
            }
        }
    }
}
