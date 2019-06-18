using System;
using System.Collections.Generic;
using System.Linq;

namespace TheGarden
{
    public class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] jagged = new string[rows][];

            Dictionary<string, int> harvest = new Dictionary<string, int>()
            {
                ["Carrots"] = 0,
                ["Potatoes"] = 0,
                ["Lettuce"] = 0
            };

            int harmed = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                jagged[row] = currentRow;
            }

            while (true)
            {
                string input = Console.ReadLine().ToLower();

                if (input == "end of harvest")
                {
                    break;
                }

                string[] splitedInput = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = splitedInput[0];
                int row = int.Parse(splitedInput[1]);
                int col = int.Parse(splitedInput[2]);

                if (command == "harvest")
                {
                    if (IsInside(jagged, row, col) && jagged[row][col] != " ")
                    {
                        string currentVeg = jagged[row][col];

                        switch (currentVeg)
                        {
                            case "C": currentVeg = "Carrots"; break;
                            case "P": currentVeg = "Potatoes"; break;
                            case "L": currentVeg = "Lettuce"; break;
                        }

                        harvest[currentVeg]++;
                        jagged[row][col] = " ";
                    }
                }
                else if (command == "mole")
                {
                    string direction = splitedInput[3];

                    while (IsInside(jagged, row, col))
                    {
                        if(jagged[row][col] != " ")
                        {
                            jagged[row][col] = " ";
                            harmed++;
                        }

                        switch(direction)
                        {
                            case "up": row-=2;
                                break;
                            case "down": row+=2;
                                break;
                            case "left": col-=2;
                                break;
                            case "right": col+=2;
                                break;
                        }
                    }
                }
            }

            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }

            foreach (var (veg, count) in harvest)
            {
                Console.WriteLine($"{veg}: {count}");
            }

            Console.WriteLine($"Harmed vegetables: {harmed}");
        }

        private static bool IsInside(string[][] jagged, int row, int col)
        {
            return row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length;
        }
    }
}