using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl.Core
{
    public class Engine
    {
        private readonly List<Entered> entereds;
        public Engine()
        {
            entereds = new List<Entered>();
        }
        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArgs = command
                    .Split();

                if(commandArgs.Length == 3)
                {
                    AddCitizen(commandArgs);
                }

                else if(commandArgs.Length == 2)
                {
                    AddRobot(commandArgs);
                }

                command = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();

            foreach (var currentId in this.entereds.Where(x => x.Id.EndsWith(fakeId)))
            {
                Console.WriteLine(currentId.Id);
            }
        }

        private void AddRobot(string[] commandArgs)
        {
            string model = commandArgs[0];
            string id = commandArgs[1];

            Robot robot = new Robot(model, id);
            entereds.Add(robot);
        }

        private void AddCitizen(string[] commandArgs)
        {
            string name = commandArgs[0];
            int age = int.Parse(commandArgs[1]);
            string id = commandArgs[2];

            Citizen citizen = new Citizen(name, age, id);
            entereds.Add(citizen);
        }
    }
}
