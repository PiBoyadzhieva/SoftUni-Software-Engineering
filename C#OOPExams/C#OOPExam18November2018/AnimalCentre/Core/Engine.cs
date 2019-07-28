using System;
using System.Linq;
using AnimalCentre.Core.Contracts;

namespace AnimalCentre.Core
{
    public class Engine : IEngine

    {
        private readonly AnimalCentre animalCentre;

        public Engine()
        {
            this.animalCentre = new AnimalCentre();
        }
        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                try
                {
                    string[] inputArgs = input
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string command = inputArgs[0];
                    string[] args = inputArgs.Skip(1).ToArray();

                    string result = ReadCommand(command, args);

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine("InvalidOperationException: " + ioe.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("ArgumentException: " + ae.Message);
                }

                input = Console.ReadLine();
            }

            string adoptedAnimals = this.animalCentre.AllAdoptedAnimals();
            Console.WriteLine(adoptedAnimals);
        }

        private string ReadCommand(string command, string[] args)
        {
            string result = string.Empty;
            string name = string.Empty;
            int procedureTime = 0;

            switch (command)
            {
                case "RegisterAnimal":
                    string type = args[0];
                    name = args[1];
                    int energy = int.Parse(args[2]);
                    int happiness = int.Parse(args[3]);
                    procedureTime = int.Parse(args[4]);

                    result = this.animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime);
                    break;
                case "Chip":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);

                    result = this.animalCentre.Chip(name, procedureTime);
                    break;
                case "Vaccinate":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);

                    result = this.animalCentre.Vaccinate(name, procedureTime);
                    break;
                case "Fitness":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);

                    result = this.animalCentre.Fitness(name, procedureTime);
                    break;
                case "Play":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);

                    result = this.animalCentre.Play(name, procedureTime);
                    break;
                case "DentalCare":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);

                    result = this.animalCentre.DentalCare(name, procedureTime);
                    break;
                case "NailTrim":
                    name = args[0];
                    procedureTime = int.Parse(args[1]);

                    result = this.animalCentre.NailTrim(name, procedureTime);
                    break;
                case "Adopt":
                    name = args[0];
                    string owner = args[1];

                    result = this.animalCentre.Adopt(name, owner);
                    break;
                case "History":
                    string procedureType = args[0];

                    result = this.animalCentre.History(procedureType);
                    break;
            }
            return result;
        }
    }
}
