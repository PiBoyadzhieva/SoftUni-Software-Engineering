using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var randomList = new RandomList();

            randomList.Add("Test");
            randomList.Add("Ivan");
            randomList.Add("Pesho");

            Console.WriteLine(randomList.RandomString());
        }
    }
}
