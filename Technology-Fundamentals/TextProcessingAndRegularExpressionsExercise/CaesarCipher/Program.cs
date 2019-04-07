using System;
using System.Text;

namespace CaesarCipher
{
    public class Program
    {

        public static void Main()
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            foreach (var symbol in text)
            {
                char currentChar = (char)(symbol + 3);
                sb.Append(currentChar);
            }

            Console.WriteLine(sb);
        }
    }
}
