using System;

namespace GenericBoxOfInteger
{
    public class StartUp
    {
        public static void Main()
        {
            int line = int.Parse(Console.ReadLine());

            for (int i = 0; i < line; i++)
            {
                int content = int.Parse(Console.ReadLine());
                Box<int> boxWithString = new Box<int>(content);

                Console.WriteLine(boxWithString.ToString());
            }
        }
    }
}
