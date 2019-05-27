using System;
using System.Collections.Generic;

namespace EvenTimes
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<int> numbers = new HashSet<int>();
            HashSet<int> dublicates = new HashSet<int>();
            

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (numbers.Contains(input))
                {
                    if(dublicates.Contains(input))
                    {
                        dublicates.Remove(input);
                    }
                    else
                    {
                        dublicates.Add(input);
                    }
                }
                else
                {
                    numbers.Add(input);
                }

            }

            foreach (var item in dublicates)
            {
                Console.WriteLine(item);
            }
        }
    }
}
