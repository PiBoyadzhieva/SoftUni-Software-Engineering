using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string[] expression = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>(expression.Reverse());

            while (stack.Count > 1)
            {
                int operand1 = int.Parse(stack.Pop());
                string operators = stack.Pop();
                int operand2 = int.Parse(stack.Pop());

                switch (operators)
                {
                    case "+":
                        stack.Push($"{operand1 + operand2}");
                        break;
                    case "-":
                        stack.Push((operand1 - operand2).ToString());
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
