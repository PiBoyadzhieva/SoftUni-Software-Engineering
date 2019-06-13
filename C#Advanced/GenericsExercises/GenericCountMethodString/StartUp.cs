using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodString
{
    public class StartUp
    {
        public static void Main()
        {
            int line = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();


            for (int i = 0; i < line; i++)
            {
                string inputLine = Console.ReadLine();

                box.Add(inputLine);
            }

            string element = Console.ReadLine();

            int count = GetCountOfGreaterElement(box.Data, element);

            Console.WriteLine(count);
        }

        public static int GetCountOfGreaterElement<T>(List<T> ListWithData, T element)
            where T : IComparable
        {
            int count = 0;

            foreach (var item in ListWithData)
            {
                if(item.CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
