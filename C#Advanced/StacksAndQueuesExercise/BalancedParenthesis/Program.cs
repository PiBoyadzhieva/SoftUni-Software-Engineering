using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParenthesis
{
    public class Program
    {
        public static void Main()
        {
            Stack<char> stackOfParenteses = new Stack<char>();

            char[] input = Console.ReadLine().ToCharArray();

            char[] openParenteses = new char[] { '(', '{', '[' };

            bool isValid = true;

            foreach (var item in input)
            {
                if (openParenteses.Contains(item))
                {
                    stackOfParenteses.Push(item);
                    continue;
                }

                if(stackOfParenteses.Count == 0)
                {
                    isValid = false;
                    break;
                }
                if(stackOfParenteses.Peek() == '(' && item == ')')
                {
                    stackOfParenteses.Pop();
                }
                else if (stackOfParenteses.Peek() == '{' && item == '}')
                {
                    stackOfParenteses.Pop();
                }
                else if (stackOfParenteses.Peek() == '[' && item == ']')
                {
                    stackOfParenteses.Pop();
                }
                else
                {
                    isValid = false;
                    break;
                }
            }

            if(isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
