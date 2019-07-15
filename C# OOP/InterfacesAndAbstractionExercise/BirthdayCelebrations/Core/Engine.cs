using System;
using System.Collections.Generic;
using System.Linq;

using BirthdayCelebrations.Contracts;
using BirthdayCelebrations.Models;

namespace BirthdayCelebrations.Core
{
    public class Engine
    {
        private readonly List<IBirthdate> birthdates;
        public Engine()
        {
            birthdates = new List<IBirthdate>();
        }
        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command
                    .Split();

                if(commandArgs[0] == "Citizen")
                {
                    AddCitizen(commandArgs);
                }

                else if(commandArgs[0] == "Robot")
                {
                    AddRobot(commandArgs);
                }

                else if(commandArgs[0] == "Pet")
                {
                    AddPet(commandArgs);
                }

                command = Console.ReadLine();
            }

            string year = Console.ReadLine();

            foreach (var currentBirthdate in this.birthdates.Where(b => b.Birthdate.EndsWith(year)))
            {
                Console.WriteLine(currentBirthdate.Birthdate);
            }
        }

        private void AddPet(string[] commandArgs)
        {
            string name = commandArgs[1];
            string birthdate = commandArgs[2];

            Pet pet = new Pet(name, birthdate);

            birthdates.Add(pet);
        }

        private void AddRobot(string[] commandArgs)
        {
            string model = commandArgs[1];
            string id = commandArgs[2];

            Robot robot = new Robot(model, id);
        }

        private void AddCitizen(string[] commandArgs)
        {
            string name = commandArgs[1];
            int age = int.Parse(commandArgs[2]);
            string id = commandArgs[3];
            string birthdate = commandArgs[4];

            Citizen citizen = new Citizen(name, age, id, birthdate);
            birthdates.Add(citizen);
        }
    }
}
