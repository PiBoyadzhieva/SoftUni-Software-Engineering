using System;
using System.Collections.Generic;

namespace SimpleTextEditor
{
    public class Program
    {
        public static void Main()
        {
            Stack<string> stackOfText = new Stack<string>();
            string text = string.Empty;

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];

                if (command == "1")
                {
                    stackOfText.Push(text);
                    text += input[1];
                }
                else if (command == "2")
                {
                    int index = int.Parse(input[1]);
                    stackOfText.Push(text);
                    text = text.Substring(0, text.Length - index);
                }
                else if(command == "3")
                {
                    int index = int.Parse(input[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if(command == "4")
                {
                    if(stackOfText.Count > 0)
                    {
                        text = stackOfText.Pop();
                    }
                }
            }
        }
    }
}
