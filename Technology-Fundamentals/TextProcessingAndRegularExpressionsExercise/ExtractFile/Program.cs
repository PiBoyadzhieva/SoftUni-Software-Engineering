using System;

namespace ExtractFile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string path = Console.ReadLine();
            int startIndexOfFile = path.LastIndexOf('\\') + 1;

            string file = path.Substring(startIndexOfFile);
            int extension = file.IndexOf('.') + 1;
            string nameOfFile = file.Substring(0, extension - 1);
            string nameOfExtension = file.Substring(extension);

            Console.WriteLine($"File name: {nameOfFile}");
            Console.WriteLine($"File extension: {nameOfExtension}");
        }
    }
}
