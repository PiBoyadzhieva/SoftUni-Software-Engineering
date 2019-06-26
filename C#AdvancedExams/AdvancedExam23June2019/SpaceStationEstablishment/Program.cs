using System;

namespace SpaceStationEstablishment
{
    public class Program
    {
        static int playerRow;
        static int playerCol;
        static int firstBlackHoleRow;
        static int firstBlackHoleCol;
        static int secondBlackHoleRow;
        static int secondBlackHoleCol;
        static int blackHoleCount;

        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];

            int energy = 0;

            FillMatrix(matrix);

            while (energy < 50)
            {
                string command = Console.ReadLine();

                int currentPlayerRow = playerRow;
                int currentPlayerCol = playerCol;

                if (command == "up")
                {
                    if (playerRow - 1 >= 0)
                    {
                        playerRow--;
                    }

                    else
                    {
                        matrix[currentPlayerRow][currentPlayerCol] = '-';
                        break;
                    }
                }
                if (command == "down")
                {
                    if (playerRow + 1 < matrix.Length)
                    {
                        playerRow++;
                    }
                    else
                    {
                        matrix[currentPlayerRow][currentPlayerCol] = '-';
                        break;
                    }
                }
                if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        playerCol--;
                    }
                    else
                    {
                        matrix[currentPlayerRow][currentPlayerCol] = '-';
                        break;
                    }
                }
                if (command == "right")
                {
                    if (playerCol + 1 < matrix[playerRow].Length)
                    {
                        playerCol++;
                    }
                    else
                    {
                        matrix[currentPlayerRow][currentPlayerCol] = '-';
                        break;
                    }
                }

                char symbolOnNextStep = matrix[playerRow][playerCol];

                if (char.IsDigit(matrix[playerRow][playerCol]))
                {
                    int number = int.Parse(matrix[playerRow][playerCol].ToString());

                    energy += number;
                    matrix[playerRow][playerCol] = 'S';
                    matrix[currentPlayerRow][currentPlayerCol] = '-';
                }

                int currentBlackHoleRow = 0;
                int currentBlackHoleCol = 0;

                if (symbolOnNextStep == '-')
                {
                    matrix[currentPlayerRow][currentPlayerCol] = '-';
                }

                else if (symbolOnNextStep == 'O')
                {
                    if (playerRow == firstBlackHoleRow && playerCol == firstBlackHoleCol)
                    {
                        currentBlackHoleRow = playerRow;
                        currentBlackHoleCol = playerCol;

                        playerRow = secondBlackHoleRow;
                        playerCol = secondBlackHoleCol;
                        matrix[playerRow][playerCol] = 'S';
                        matrix[currentBlackHoleRow][currentBlackHoleCol] = '-';
                        matrix[currentPlayerRow][currentPlayerCol] = '-';

                    }

                    else if (playerRow == secondBlackHoleRow && playerCol == secondBlackHoleCol)
                    {
                        currentBlackHoleRow = playerRow;
                        currentBlackHoleCol = playerCol;

                        playerRow = firstBlackHoleRow;
                        playerCol = firstBlackHoleCol;
                        matrix[playerRow][playerCol] = 'S';
                        matrix[currentBlackHoleRow][currentBlackHoleCol] = '-';
                        matrix[currentPlayerRow][currentPlayerCol] = '-';
                    }
                }
            }

            PrintMatrix(matrix, energy);
        }

        private static void PrintMatrix(char[][] matrix, int energy)
        {
            if (energy < 50)
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }
            else
            {
                Console.WriteLine($"Good news! Stephen succeeded in collecting enough star power!");
            }

            Console.WriteLine($"Star power collected: {energy}");

            for (int row = 0; row < matrix.Length; row++)
            {
                char[] currentRow = matrix[row];

                Console.WriteLine(string.Join("", currentRow));
            }
        }

        private static void FillMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                matrix[row] = new char[currentRow.Length];

                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row][col] = currentRow[col];

                    if (matrix[row][col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    else if (matrix[row][col] == 'O' && blackHoleCount == 0)
                    {
                        firstBlackHoleRow = row;
                        firstBlackHoleCol = col;
                        blackHoleCount++;
                    }

                    else if (matrix[row][col] == 'O' && blackHoleCount == 1)
                    {
                        secondBlackHoleRow = row;
                        secondBlackHoleCol = col;
                    }
                }
            }
        }
    }
}
