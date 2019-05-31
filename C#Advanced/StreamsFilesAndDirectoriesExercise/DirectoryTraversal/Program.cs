using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, double>> dirInfo = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo directoryInfo = new DirectoryInfo(".");

            FileInfo[] allFiles = directoryInfo.GetFiles();

            foreach (FileInfo currentFile in allFiles)
            {
                double size = currentFile.Length / 1024d;
                string fileName = currentFile.Name;
                string extention = currentFile.Extension;

                if(!dirInfo.ContainsKey(extention))
                {
                    dirInfo.Add(extention, new Dictionary<string, double>());
                }

                if(!dirInfo[extention].ContainsKey(fileName))
                {
                    dirInfo[extention].Add(fileName, size);
                }
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/report.txt";

            var sortedDir = dirInfo.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var (extention, value) in sortedDir)
            {
                File.AppendAllText(path, extention + Environment.NewLine);

                foreach (var (fileName, size) in value.OrderBy(x => x.Value))
                {
                    File.AppendAllText(path, $"--{fileName} - {Math.Round(size, 3)}kb {Environment.NewLine}");
                }
            }
        }
    }
}
