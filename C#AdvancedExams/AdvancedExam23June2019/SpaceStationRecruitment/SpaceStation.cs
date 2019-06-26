using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> spaceStation;

        public SpaceStation(string name, int capacity)
        {
            this.spaceStation = new List<Astronaut>();
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Count => this.spaceStation.Count;


        public void Add(Astronaut astronaut)
        {
            if (this.Capacity > this.spaceStation.Count)
            {
                this.spaceStation.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            if (this.spaceStation.Any(a => a.Name == name))
            {
                this.spaceStation.Remove(this.spaceStation.FirstOrDefault(a => a.Name == name));
                return true;
            }
            return false;
        }
        public Astronaut GetOldestAstronaut()
        {
            var result = this.spaceStation.OrderByDescending(a => a.Age).FirstOrDefault();
            return result;
        }

        public Astronaut GetAstronaut(string name)
        {
            var result = this.spaceStation.FirstOrDefault(a => a.Name == name);
            return result;
        }

        public string Report()
        {
            var result = new StringBuilder();

            result.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in this.spaceStation)
            {
                result.AppendLine($"{astronaut}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
