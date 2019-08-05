using MXGP.Core.Contracts;
using System;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private IChampionshipController championshipController;

        public Engine()
        {
            this.championshipController = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = inputInfo[0];

                if (command == "End")
                {
                    break;
                }

                try
                {
                    if (command == "CreateRider")
                    {
                        string name = inputInfo[1];

                        var result = championshipController.CreateRider(name);

                        Console.WriteLine(result);
                    }
                    else if (command == "CreateMotorcycle")
                    {
                        string type = inputInfo[1];
                        string model = inputInfo[2];
                        int horsePower = int.Parse(inputInfo[3]);

                        var result = championshipController.CreateMotorcycle(type, model, horsePower);

                        Console.WriteLine(result);
                    }
                    else if (command == "AddMotorcycleToRider")
                    {
                        string name = inputInfo[1];
                        string model = inputInfo[2];

                        var result = championshipController.AddMotorcycleToRider(name, model);

                        Console.WriteLine(result);
                    }
                    else if (command == "AddRiderToRace")
                    {
                        string raceName = inputInfo[1];
                        string riderName = inputInfo[2];

                        var result = championshipController.AddRiderToRace(raceName, riderName);

                        Console.WriteLine(result);
                    }

                    else if (command == "CreateRace")
                    {
                        string name = inputInfo[1];
                        int laps = int.Parse(inputInfo[2]);

                        var result = championshipController.CreateRace(name, laps);

                        Console.WriteLine(result);
                    }

                    else if (command == "StartRace")
                    {
                        string name = inputInfo[1];

                        var result = championshipController.StartRace(name);

                        Console.WriteLine(result);
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
