using System;
using System.Collections.Generic;

namespace TrafficJam
{
    public class Program
    {
        public static void Main()
        {
            Queue<string> queue = new Queue<string>();
            int count = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            int number = 0;

            while (command?.ToLower() != "end")
            {
                if(command?.ToLower() == "green")
                {
                    int currentCount = queue.Count > count ? count : queue.Count;

                    for (int i = 0; i < currentCount; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        number++;
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{number} cars passed the crossroads.");
        }
    }
}
