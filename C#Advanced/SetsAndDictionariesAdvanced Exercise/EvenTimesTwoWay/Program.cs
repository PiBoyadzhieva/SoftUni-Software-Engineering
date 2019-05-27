using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimesTwoWay
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if(!numbers.ContainsKey(currentNumber))
                {
                    numbers.Add(currentNumber, 0);
                }

                numbers[currentNumber]++;
            }

            int evenTimesNumber = numbers
                .SingleOrDefault(number => number.Value % 2 == 0)
                .Key;

            Console.WriteLine(evenTimesNumber);
        }
    }
}
