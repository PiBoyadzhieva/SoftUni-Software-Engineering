namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private readonly IList<IPilot> pilots;
        private readonly IList<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }


        public string HirePilot(string name)
        {
            if (pilots.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }

            IPilot pilot = new Pilot(name);
            this.pilots.Add(pilot);

            return string.Format(OutputMessages.PilotHired, pilot.Name);
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if(this.machines.Any(t => t.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            ITank tank = new Tank(name, attackPoints, defensePoints);
            this.machines.Add(tank);

            return string.Format(OutputMessages.TankManufactured,
                tank.Name,
                tank.AttackPoints,
                tank.DefensePoints);

        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if(this.machines.Any(f => f.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            IFighter fighter = new Fighter(name, attackPoints, defensePoints);
            this.machines.Add(fighter);

            return string.Format(OutputMessages.FighterManufactured,
                fighter.Name,
                fighter.AttackPoints,
                fighter.DefensePoints,
                fighter.AggressiveMode == true ? "ON" : "OFF");
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);
            var machine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, machine.Name);
            }

            machine.Pilot = pilot;
            pilot.AddMachine(machine);

            return string.Format(OutputMessages.MachineEngaged, pilot.Name, machine.Name);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackMachine = this.machines.FirstOrDefault(p => p.Name == attackingMachineName);
            var defenceMachine = this.machines.FirstOrDefault(p => p.Name == defendingMachineName);

            if(attackMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);

            }
            if (defenceMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if(attackMachine.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }

            if(defenceMachine.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attackMachine.Attack(defenceMachine);

            return string.Format(OutputMessages.AttackSuccessful,
                defenceMachine.Name,
                attackMachine.Name,
                defenceMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            string result = pilot.Report();
            return result;
        }

        public string MachineReport(string machineName)
        {
            var machine = machines.FirstOrDefault(m => m.Name == machineName);

            string result = machine.ToString();
            return result;
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            //var fighter = (IFighter)this.machines.FirstOrDefault(f => f.Name == fighterName && f.GetType() == typeof(Fighter));
            var fighter = (IFighter)this.machines.FirstOrDefault(f => f.Name == fighterName);

            if (fighter == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            fighter.ToggleAggressiveMode();

            return string.Format(OutputMessages.FighterOperationSuccessful, fighter.Name);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            //var tank = (ITank)this.machines.FirstOrDefault(t => t.Name == tankName && t.GetType() == typeof(Tank));
            var tank = (ITank)this.machines.FirstOrDefault(t => t.Name == tankName);

            if (tank == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            tank.ToggleDefenseMode();

            return string.Format(OutputMessages.TankOperationSuccessful, tank.Name);
        }
    }
}