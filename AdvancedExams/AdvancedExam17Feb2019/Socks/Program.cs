using System;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    public class Program
    {
        public static void Main()
        {
            int[] inputLeftSocks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] inputRightSocks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> leftSocks = new Stack<int>(inputLeftSocks);
            Stack<int> rightSocks = new Stack<int>(inputRightSocks.Reverse());

            List<int> pair = new List<int>();

            while (leftSocks.Any() && rightSocks.Any())
            {
                int currentLeftSock = leftSocks.Pop();
                int currentRightSock = rightSocks.Pop();

                if(currentLeftSock > currentRightSock)
                {
                    pair.Add(currentLeftSock + currentRightSock);
                }
                else if(currentRightSock > currentLeftSock)
                {
                    rightSocks.Push(currentRightSock);
                    continue;
                }

                else if(currentLeftSock == currentRightSock)
                {
                    currentLeftSock += 1;
                    leftSocks.Push(currentLeftSock);
                    continue;
                }
            }

            Console.WriteLine(pair.Max());
            Console.WriteLine(string.Join(" ", pair));
        }
    }
}
