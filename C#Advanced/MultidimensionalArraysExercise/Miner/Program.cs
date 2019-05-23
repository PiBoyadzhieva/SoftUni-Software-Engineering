using System;
using System.Linq;

namespace Miner
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            char[][] matrix = new char[n][];

            int playerRow = -1;
            int playerCol = -1;
            int coalLeft = 0;

            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine().Replace(" ", "").ToCharArray();

                if(matrix[row].Contains('s'))
                {
                    playerRow = row;
                    playerCol = Array.IndexOf(matrix[row], 's');
                    matrix[row][playerCol] = '*';
                }

                coalLeft += matrix[row].Where(c => c == 'c').Count();
            }

            foreach (var command in commands)
            {
                switch(command)
                {
                    case "up":
                        playerRow = playerRow - 1 < 0 ? playerRow : playerRow - 1;
                        break;
                    case "down":
                        playerRow = playerRow + 1 >= n ? playerRow : playerRow + 1;
                        break;
                    case "left":
                        playerCol = playerCol - 1 < 0 ? playerCol : playerCol - 1;
                        break;
                    case "right":
                        playerCol = playerCol + 1 >= n ? playerCol : playerCol + 1;
                        break;
                }

                if(matrix[playerRow][playerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({playerRow}, {playerCol})");
                    return;
                }
                else if(matrix[playerRow][playerCol] == 'c')
                {
                    matrix[playerRow][playerCol] = '*';
                    coalLeft--;

                    if(coalLeft == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{coalLeft} coals left. ({playerRow}, {playerCol})");  
        }
    }
}
