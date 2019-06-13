using System;

namespace ThreeupleDemo
{
    public class StartUp
    {
        public static void Main()
        {
            string[] firstInput = Console.ReadLine()
                .Split();

            string name = firstInput[0] + " " + firstInput[1];
            string adress = firstInput[2];
            string town = firstInput[3];

            Tuple<string, string, string> firstTuple = new Tuple<string, string, string>(name, adress, town);

            string[] secondInput = Console.ReadLine()
                .Split();

            string secondName = secondInput[0];
            int liters = int.Parse(secondInput[1]);
            bool isDrunk = secondInput[2].ToLower() == "drunk" ? true : false;

            Tuple<string, int, bool> secondTuple = new Tuple<string, int, bool>(secondName, liters, isDrunk);

            string[] thirdInput = Console.ReadLine()
                .Split();

            string thirdName = thirdInput[0];
            double balance = double.Parse(thirdInput[1]);
            string bankName = thirdInput[2];


            Tuple<string, double, string> thirdTuple = new Tuple<string, double, string>(thirdName, balance, bankName);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);

        }
    }
}
