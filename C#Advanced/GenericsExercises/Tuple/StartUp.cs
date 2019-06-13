using System;

namespace TupleDemo

{
    public class StartUp
    {
        public static void Main()
        {
            string[] firstInput = Console.ReadLine()
                .Split();

            string name = firstInput[0] + " " + firstInput[1];
            string adress = firstInput[2];

            Tuple<string, string> firstTuple = new Tuple<string, string>(name, adress);

            string[] secondInput = Console.ReadLine()
                .Split();

            string secondName = secondInput[0];
            int liters = int.Parse(secondInput[1]);

            Tuple<string, int> secondTuple = new Tuple<string, int>(secondName, liters);

            string[] thirdInput = Console.ReadLine()
                .Split();

            int intNumber = int.Parse(thirdInput[0]);
            double doubleNumber = double.Parse(thirdInput[1]);

            Tuple<int, double> thirdTuple = new Tuple<int, double>(intNumber, doubleNumber);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);
        }
    }
}
