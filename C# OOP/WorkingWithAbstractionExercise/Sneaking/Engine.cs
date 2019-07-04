using System;

namespace Sneaking
{
    public class Engine
    {
        private static char[][] room;
        private static int[] samPosition;

        public void Run()
        {
            int rows = int.Parse(Console.ReadLine());

            room = new char[rows][];
            samPosition = new int[2];

            bool isSamDead = false;
            bool isNikolazeDead = false;

            FillTheMatrix(rows);

            var moves = Console.ReadLine().ToCharArray();

            for (int i = 0; i < moves.Length; i++)
            {
                EnemiesMove();

                int[] enemy = new int[2];

                GetEnemy(enemy);

                if ((samPosition[1] < enemy[1] && room[enemy[0]][enemy[1]] == 'd' && enemy[0] == samPosition[0]) ||
                    (enemy[1] < samPosition[1] && room[enemy[0]][enemy[1]] == 'b' && enemy[0] == samPosition[0]))
                {
                    room[samPosition[0]][samPosition[1]] = 'X';
                    isSamDead = true;
                    break;
                }

                room[samPosition[0]][samPosition[1]] = '.';

                switch (moves[i])
                {
                    case 'U':
                        samPosition[0]--;
                        break;
                    case 'D':
                        samPosition[0]++;
                        break;
                    case 'L':
                        samPosition[1]--;
                        break;
                    case 'R':
                        samPosition[1]++;
                        break;
                    default:
                        break;
                }

                room[samPosition[0]][samPosition[1]] = 'S';

                GetEnemy(enemy);

                if (room[enemy[0]][enemy[1]] == 'N' && samPosition[0] == enemy[0])
                {
                    room[enemy[0]][enemy[1]] = 'X';

                    isNikolazeDead = true;
                    break;
                }
            }

            if (isSamDead)
            {
                Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
            }
            else if (isNikolazeDead)
            {
                Console.WriteLine("Nikoladze killed!");
            }

            for (int row = 0; row < room.GetLength(0); row++)
            {
                Console.WriteLine(string.Join("", room[row]));
            }
        }

        private static void GetEnemy(int[] enemy)
        {
            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    enemy[0] = samPosition[0];
                    enemy[1] = j;
                }
            }
        }

        private static void EnemiesMove()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private static void FillTheMatrix(int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                var col = Console.ReadLine().ToCharArray();

                room[row] = col;

                for (int symbol = 0; symbol < col.Length; symbol++)
                {
                    if (room[row][symbol] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = symbol;
                    }
                }
            }
        }
    }
}
