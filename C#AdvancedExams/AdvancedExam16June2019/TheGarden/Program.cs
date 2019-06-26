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
                string input = Console.ReadLine();

                if (input == "End of Harvest")
                {
                    break;
                }

                string[] splitedInput = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = splitedInput[0].ToLower();
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
                    string direction = splitedInput[3].ToLower();

                    if (IsInside(jagged, row, col))
                    {
                        if (direction == "up")
                        {
                            for (int currentRow = row; currentRow >= 0; currentRow -= 2)
                            {
                                if (IsInside(jagged, currentRow, col) && jagged[currentRow][col] != " ")
                                {
                                    jagged[currentRow][col] = " ";
                                    harmed++;
                                }
                            }
                        }
                        else if (direction == "down")
                        {
                            for (int currentRow = row; currentRow < jagged.Length; currentRow += 2)
                            {
                                if (IsInside(jagged, currentRow, col) && jagged[currentRow][col] != " ")
                                {
                                    jagged[currentRow][col] = " ";
                                    harmed++;
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int currentCol = col; currentCol >= 0; currentCol -= 2)
                            {
                                if (IsInside(jagged, row, currentCol) && jagged[row][currentCol] != " ")
                                {
                                    jagged[row][currentCol] = " ";
                                    harmed++;
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int currentCol = col; currentCol < jagged[row].Length; currentCol += 2)
                            {
                                if (IsInside(jagged, row, currentCol) && jagged[row][currentCol] != " ")
                                {
                                    jagged[row][currentCol] = " ";
                                    harmed++;
                                }
                            }
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
