using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    public class Program
    {
        public static void Main()
        {
            Queue<string> queue = new Queue<string>();
            StringBuilder sb = new StringBuilder();
            int counter = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "End")
                {
                    break;
                }

                if (input == "Paid")
                {
                    int clients = queue.Count;

                    for (int i = 0; i < clients; i++)
                    {
                        string remove = queue.Dequeue();
                        sb.AppendLine(remove);
                        counter++;
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }

            if(sb.Capacity != 0)
            {
                for (int i = 0; i < counter; i++)
                {
                    Console.WriteLine();
                }
                Console.Write(sb);
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
