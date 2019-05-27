using System;
using System.Text.RegularExpressions;

namespace SongEncryption
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();
                string encryptedInput = string.Empty;
                bool isValid = false;

                if (input == "end")
                {
                    break;
                }

                string[] inputToCheck = input.Split(":");

                string artist = inputToCheck[0];

                string regex = @"^([A-Z]{1}[a-z\' ]+):([A-Z ]+)\b";

                if (Regex.IsMatch(input, regex))
                {
                    isValid = true;

                    for (int i = 0; i < input.Length; i++)
                    {
                        int key = artist.Length;
                        char currentChar = input[i];
                        char newChar = ' ';

                        if (currentChar == ':')
                        {
                            newChar = '@';
                        }

                        else if(char.IsLetter(currentChar))
                        {
                            newChar = (char)(currentChar + key);

                            if (char.IsLower(currentChar) && newChar > 122)
                            {
                                key = newChar - 122;
                                newChar = (char)('a' + key - 1);
                            }

                            if (char.IsUpper(currentChar) && newChar > 90)
                            {
                                key = newChar - 90;
                                newChar = (char)('A' + key - 1);
                            }
                        }

                        else
                        {
                            newChar = currentChar;
                        }

                        encryptedInput += newChar;

                    }
                }

                if (isValid == false)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    Console.WriteLine($"Successful encryption: {encryptedInput}");
                }
            }
        }
    }
}
