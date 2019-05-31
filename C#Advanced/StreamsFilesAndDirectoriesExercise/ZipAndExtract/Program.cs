using System;
using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    public class Program
    {
        public static void Main()
        {
            string zipFile = "myNewZip.zip";
            string file = "copyMe.png";

            using (var archive = ZipFile.Open(zipFile, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(file, Path.GetFileName(file));
            }
        }
    }
}
