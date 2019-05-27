using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _28102018ChoreWars
{
    public class Program
    {
        public static void Main()
        {
            int dishiesTime = 0;
            int cleaningTime = 0;
            int laundryTime = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "wife is happy")
                {
                    break;
                }

                string dishiesPattern = @"<[a-z0-9]+>";
                string cleaningPattern = @"\[[A-Z0-9]+\]";
                string laundryPattern = @"\{.*\}";

                var disheshMatch = Regex.Match(input, dishiesPattern).ToString();
                var houseMatch = Regex.Match(input, cleaningPattern).ToString();
                var laundryMatch = Regex.Match(input, laundryPattern).ToString();

                if (!string.IsNullOrEmpty(disheshMatch))
                {
                    for (int i = 0; i < disheshMatch.Length; i++)
                    {
                        if (char.IsNumber(disheshMatch[i]))
                        {
                            int number = int.Parse(disheshMatch[i].ToString());
                            dishiesTime += number;
                        }
                    }
                }

                else if (!string.IsNullOrEmpty(houseMatch))
                {
                    for (int i = 0; i < houseMatch.Length; i++)
                    {
                        if (char.IsNumber(houseMatch[i]))
                        {
                            int number = int.Parse(houseMatch[i].ToString());
                            cleaningTime += number;
                        }
                    }
                }

                else if (!string.IsNullOrEmpty(laundryMatch))
                {
                    for (int i = 0; i < laundryMatch.Length; i++)
                    {
                        if (char.IsNumber(laundryMatch[i]))
                        {
                            int number = int.Parse(laundryMatch[i].ToString());
                            laundryTime += number;
                        }
                    }
                }
            }

            int totalTime = cleaningTime + dishiesTime + laundryTime;

            Console.WriteLine($"Doing the dishes - {dishiesTime} min.");
            Console.WriteLine($"Cleaning the house - {cleaningTime} min.");
            Console.WriteLine($"Doing the laundry - {laundryTime} min.");
            Console.WriteLine($"Total - {totalTime} min.");
        }
    }
}
