﻿using System;

namespace RhombusOfStars
{
    public class Program
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                PrintRow(row, n);
            }

            for (int row = n - 2; row >= 0; row--)
            {
                PrintRow(row, n);
            }
        }

        private static void PrintRow(int row, int n)
        {
            for (int i = 0; i < n - row; i++)
            {
                Console.Write($" ");
            }
            for (int i = 0; i < row + 1; i++)
            {
                Console.Write($"* ");
            }
            for (int i = 1; i < row; i++)
            {
                Console.Write($" ");
            }

            Console.WriteLine();
        }
    }
}
