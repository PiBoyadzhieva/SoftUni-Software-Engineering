using System;
using System.Linq;

namespace TriFunction
{
    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> isLarger = (name, charsLength) => name.Sum(x => x) >= charsLength;

            Func<string[], Func<string, int, bool>, string> nameFilter = (inputNames, isLargerFilter)
                => inputNames.FirstOrDefault(x => isLargerFilter(x, number));

            string resultName = nameFilter(names, isLarger);

            Console.WriteLine(resultName);

            ///Func<string, char[]> funcToCharArr = x => x.ToCharArray();
            ///Func<char, int> castFunc = y => y;
            ///Func<string, bool> finalFunc = x => funcToCharArr(x).Select(castFunc).Sum() >= number;

            ///Console.WriteLine(Console.ReadLine()
            ///    .Split()
            ///    .FirstOrDefault(finalFunc));

            //Console.WriteLine(Console.ReadLine()
            //    .Split()
            //    .FirstOrDefault(x => x.ToCharArray()
            //    .Select(y => (int)y)
            //    .Sum() >= number));


        }
    }
}
