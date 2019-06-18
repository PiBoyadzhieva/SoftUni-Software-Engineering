using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExcelFunctions
{
    public class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            var jaggedArr = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                jaggedArr[row] = currentRow;
            }

            string[] command = Console.ReadLine()
                .Split();
            
            string header = command[1];
            int targetIndex = Array.IndexOf(jaggedArr[0], header);

            if (command[0] == "hide")
            {
                StringBuilder sb = new StringBuilder();

                for (int row = 0; row < jaggedArr.GetLength(0); row++)
                {
                    List<string> line = new List<string>();

                    for (int col = 0; col < jaggedArr[0].Length; col++)
                    {
                        if (col != targetIndex)
                        {
                            line.Add(jaggedArr[row][col]);
                        }
                    }

                    sb.AppendLine(string.Join(" | ", line));
                }

                Console.WriteLine(sb.ToString().TrimEnd());
            }

            else if (command[0] == "sort")
            {

                Console.WriteLine(string.Join(" | ", jaggedArr[0]));

                foreach (var row in jaggedArr.Skip(1).OrderBy(r => r[targetIndex]))
                {
                    Console.WriteLine($"{string.Join(" | ", row)}");
                }
            }

            else if (command[0] == "filter")
            {
                string value = command[2];

                Console.WriteLine(string.Join(" | ", jaggedArr[0]));

                for (int row = 0; row < rows; row++)
                {
                    if (jaggedArr[row][targetIndex] == value)
                    {
                        Console.WriteLine(string.Join(" | ", jaggedArr[row]));
                    }
                }
            }
        }
    }
}
