using System;

namespace HelensAbduction
{
    public class Program
    {
        static int parisRow;
        static int parisCol;

        public static void Main()
        {
            int energy = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            char[][] field = new char[rows][];

            for (int row = 0; row < field.Length; row++)
            {
                char[] input = Console.ReadLine()
                    .ToCharArray();

                field[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    field[row][col] = input[col];

                    if (field[row][col] == 'P')
                    {
                        parisRow = row;
                        parisCol = col;
                    }
                }
            }

            bool won = false;

            while (energy > 0)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string direction = input[0];
                int spawnRow = int.Parse(input[1]);
                int spawnCol = int.Parse(input[2]);

                field[spawnRow][spawnCol] = 'S';

                field[parisRow][parisCol] = '-';

                MoveInDirection(field, direction);
                energy--;

                char symbolOnNextStep = field[parisRow][parisCol];

                if(symbolOnNextStep == 'S')
                {
                    energy -= 2;
                    field[parisRow][parisCol] = 'P';
                }

                else if(symbolOnNextStep == 'H')
                {
                    won = true;
                    field[parisRow][parisCol] = '-';
                    break;
                }

                else if(symbolOnNextStep == '-')
                {
                    field[parisRow][parisCol] = 'P';
                }

                if(energy <= 0)
                {
                    field[parisRow][parisCol] = 'X';
                    break;
                }
            }

            PrintOutput(field, won, energy);
        }

        private static void PrintOutput(char[][] field, bool won, int energy)
        {
            if(won)
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
            }
            else
            {
                Console.WriteLine($"Paris died at {parisRow}; {parisCol}.");
            }

            PrintMatrix(field);
        }

        private static void PrintMatrix(char[][] field)
        {
            for (int row = 0; row < field.Length; row++)
            {
                char[] currentRow = field[row];

                Console.WriteLine(string.Join("", currentRow));
            }
        }

        private static void MoveInDirection(char[][] field, string direction)
        {
            if (direction == "up")
            {
                if(parisRow - 1 >= 0)
                {
                    parisRow--;
                }
            }

            if (direction == "down")
            {
                if(parisRow + 1 < field.Length)
                {
                    parisRow++;
                }
            }
            if (direction == "left")
            {
                if(parisCol - 1 >= 0)
                {
                    parisCol--;
                }
            }
            if (direction == "right")
            {
                if(parisCol + 1 < field[parisRow].Length)
                {
                    parisCol++;
                }
            }

        }
    }
}
