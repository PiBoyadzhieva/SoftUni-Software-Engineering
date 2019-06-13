using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        public static void Main()
        {
            int line = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();


            for (int i = 0; i < line; i++)
            {
                double inputLine = double.Parse(Console.ReadLine());

                box.Add(inputLine);
            }

            double element = double.Parse(Console.ReadLine());

            int count = GetCountOfGreaterElement(box.Data, element);

            Console.WriteLine(count);
        }

        public static int GetCountOfGreaterElement<T>(List<T> ListWithData, T element)
            where T : IComparable
        {
            int count = 0;

            foreach (var item in ListWithData)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
