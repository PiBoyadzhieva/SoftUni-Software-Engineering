using System;

using Telephony.Models;
using Telephony.Exceptions;

namespace Telephony.Core
{
    public class Engine
    {
        private readonly Smartphone smartphone;
        public Engine()
        {
            this.smartphone = new Smartphone();
        }

        public void Run()
        {
            string[] numbers = Console.ReadLine()
                .Split(" ");

            string[] urls = Console.ReadLine()
                .Split(" ");

            CallNumbers(numbers);

            BrowseInternet(urls);
        }

        private void BrowseInternet(string[] urls)
        {
            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Browse(url));
                }
                catch (InvalidURLException iurle)
                {
                    Console.WriteLine(iurle.Message);
                }
            }
        }

        private void CallNumbers(string[] numbers)
        {
            foreach (var number in numbers)
            {
                try
                {
                    Console.WriteLine(this.smartphone.Call(number));
                }
                catch (InvalidPhoneNumberException ipne)
                {
                    Console.WriteLine(ipne.Message);
                }
            }
        }
    }
}
