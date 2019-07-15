using System;

using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.Models;

namespace ExplicitInterfaces.Core
{
    public class Engine
    {
        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input
                    .Split();

                string name = inputArgs[0];
                string country = inputArgs[1];
                int age = int.Parse(inputArgs[2]);

                IPerson person = new Citizen(name, age, country);
                IResident resident = new Citizen(name, age, country);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                input = Console.ReadLine();
            }
        }
    }
}
