using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    public class Program
    {
        public static void Main()
        {
            int capacity = int.Parse(Console.ReadLine());

            string[] entry = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Stack<string> peopleAndHalls = new Stack<string>(entry);

            List<int> allGroups = new List<int>();

            Queue<string> halls = new Queue<string>();

            int currentCapacity = 0;

            while (peopleAndHalls.Any())
            {
                string currentInput = peopleAndHalls.Pop();

                bool isNumber = int.TryParse(currentInput, out int parsedNumber);

                if (!isNumber)
                {
                    halls.Enqueue(currentInput);
                }

                else
                {
                    if(halls.Count == 0)
                    {
                        continue;
                    }

                    if(currentCapacity + parsedNumber > capacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", allGroups)}");
                        allGroups.Clear();
                        currentCapacity = 0;
                    }

                    if(halls.Count > 0)
                    {
                        allGroups.Add(parsedNumber);
                        currentCapacity += parsedNumber;
                    }
                }

            }

        }
    }
}
