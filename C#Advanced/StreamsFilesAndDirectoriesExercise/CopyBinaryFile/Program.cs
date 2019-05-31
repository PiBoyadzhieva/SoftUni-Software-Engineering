using System;
using System.IO;

namespace CopyBinaryFile
{
    public class Program
    {
        public static void Main()
        {
            string picPath = "copyMe.Png";
            string picPathCopy = "copyMe-copy.Png";

            using(FileStream streamReader = new FileStream(picPath, FileMode.Open))
            {
                using(FileStream streamWriter = new FileStream(picPathCopy, FileMode.Create))
                {
                    while (true)
                    {
                        byte[] byteArray = new byte[4096];

                        int size = streamReader.Read(byteArray, 0, byteArray.Length);

                        if(size == 0)
                        {
                            break;
                        }

                        streamWriter.Write(byteArray, 0, size);

                    }
                }
            }
        }
    }
}
