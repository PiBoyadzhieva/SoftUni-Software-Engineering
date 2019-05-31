using System;
using System.IO;
using System.Linq;

namespace LineNumbers
{
    public class Program
    {
        public static void Main()
        {
            string textPath = @"text.txt";
            string outputPath = "output.txt";

            string[] textLines = File.ReadAllLines(textPath);

            int counter = 1;

            foreach (var currentLine in textLines)
            {
                int lettersCount = currentLine.Count(char.IsLetter);
                int puncsCount = currentLine.Count(char.IsPunctuation);

                File.AppendAllText(outputPath, $"Line {counter}: {currentLine} ({lettersCount})({puncsCount}){Environment.NewLine}");

                counter++;
            }
        }
    }
}
