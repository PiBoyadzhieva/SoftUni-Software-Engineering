using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ActivationKeys
{
    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split("&");
            List<string> validKeys = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                string currentText = input[i];

                string pattern = @"[0-9,A-Z,a-z]{16,25}";
                StringBuilder sb = new StringBuilder();
                string key = String.Empty;

                if (Regex.IsMatch(currentText, pattern))
                {
                    key = currentText.ToUpper();
                }

                if (key.Length == 16)
                {
                    for (int j = 0; j < key.Length; j++)
                    {
                        char currentChar = key[j];

                        if (j!= 0 && j % 4 == 0)
                        {
                            sb.Append("-");
                        }

                        if (char.IsDigit(currentChar))
                        {
                            int number = 9 - int.Parse(currentChar.ToString());
                            sb.Append(number.ToString());
                        }

                        else
                        {
                            sb.Append(currentChar);
                        }
                    }

                    validKeys.Add(sb.ToString());
                }

                if (key.Length == 25)
                {
                    for (int j = 0; j < key.Length; j++)
                    {
                        char currentChar = key[j];

                        if (j != 0 && j % 5 == 0)
                        {
                            sb.Append("-");
                        }

                        if (char.IsDigit(currentChar))
                        {
                            int number = 9 - int.Parse(currentChar.ToString());
                            sb.Append(number.ToString());
                        }

                        else
                        {
                            sb.Append(currentChar);
                        }
                    }

                    validKeys.Add(sb.ToString());
                }
            }

            Console.WriteLine(string.Join(", ", validKeys));
        }
    }
}
