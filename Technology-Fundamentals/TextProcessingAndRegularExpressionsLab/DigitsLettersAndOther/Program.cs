using System;

namespace DigitsLettersAndOther
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string digit = string.Empty;
            string letter = string.Empty;
            string others = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char character = input[i];

                if(char.IsDigit(character))
                {
                    digit += character;
                }
                else if(char.IsLetter(character))
                {
                    letter += character;
                }
                else
                {
                    others += character;
                }
            }

            Console.WriteLine(digit);
            Console.WriteLine(letter);
            Console.WriteLine(others);
        }
    }
}
