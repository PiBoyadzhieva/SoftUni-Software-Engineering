using MortalEngines.Core.Contracts;
using MortalEngines.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class Engine : IEngine
    {
        private readonly MachinesManager machinesManager;

        public Engine()
        {
            this.machinesManager = new MachinesManager();
        }
        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "Quit")
            {
                string[] inputCommand = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string result = String.Empty;

                try
                {
                    if (inputCommand[0] == "HirePilot")
                    {
                        string name = inputCommand[1];

                        result = machinesManager.HirePilot(name);
                    }
                    else if (inputCommand[0] == "PilotReport")
                    {
                        string name = inputCommand[1];

                        result = machinesManager.PilotReport(name);

                    }
                    else if (inputCommand[0] == "ManufactureTank")
                    {
                        string name = inputCommand[1];
                        double attack = double.Parse(inputCommand[2]);
                        double defense = double.Parse(inputCommand[3]);

                        result = machinesManager.ManufactureTank(name, attack, defense);
                    }
                    else if (inputCommand[0] == "ManufactureFighter")
                    {
                        string name = inputCommand[1];
                        double attack = double.Parse(inputCommand[2]);
                        double defense = double.Parse(inputCommand[3]);

                        result = machinesManager.ManufactureFighter(name, attack, defense);
                    }
                    else if (inputCommand[0] == "MachineReport")
                    {
                        string name = inputCommand[1];

                        result = machinesManager.MachineReport(name);
                    }
                    else if (inputCommand[0] == "AggressiveMode")
                    {
                        string name = inputCommand[1];

                        result = machinesManager.ToggleFighterAggressiveMode(name);
                    }
                    else if (inputCommand[0] == "DefenseMode")
                    {
                        string name = inputCommand[1];

                        result = machinesManager.ToggleTankDefenseMode(name);
                    }
                    else if (inputCommand[0] == "Engage")
                    {
                        string pilotName = inputCommand[1];
                        string machineName = inputCommand[2];

                        result = machinesManager.EngageMachine(pilotName, machineName);
                    }
                    else if (inputCommand[0] == "Attack")
                    {
                        string attackingMachineName = inputCommand[1];
                        string defendingMachineName = inputCommand[2];

                        result = machinesManager.AttackMachines(attackingMachineName, defendingMachineName);
                    }

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
