using System;

namespace GenericBoxOfString
{
    public class StartUp
    {
        public static void Main()
        {
            int line = int.Parse(Console.ReadLine());

            for (int i = 0; i < line; i++)
            {
                string content = Console.ReadLine();
                Box<string> boxWithString = new Box<string>(content);

                Console.WriteLine(boxWithString.ToString());
            }
        }
    }
}
