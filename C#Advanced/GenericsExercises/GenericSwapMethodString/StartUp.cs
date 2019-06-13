using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
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

            int[] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            Swap(box.Data, firstIndex, secondIndex);

            Console.WriteLine(box.ToString());
        }

        public static void Swap<T>(List<T> ListWithData, int firstIndex, int secondIndex)
        {
            T temp = ListWithData[firstIndex];
            ListWithData[firstIndex] = ListWithData[secondIndex];
            ListWithData[secondIndex] = temp;
        }

    }
}
