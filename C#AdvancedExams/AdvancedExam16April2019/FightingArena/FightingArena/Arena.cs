using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public string Name { get; private set; }
        public int Count => this.gladiators.Count;

        public void Add (Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove (string name)
        {
            this.gladiators.RemoveAll(g => g.Name == name);
        }
        public Gladiator GetGladitorWithHighestStatPower()
        {
            var result = this.gladiators.OrderByDescending(g => g.GetStatPower()).FirstOrDefault();

            return result;
        }
        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            var result = this.gladiators.OrderByDescending(g => g.GetWeaponPower()).FirstOrDefault();

            return result;
        }
        public Gladiator GetGladitorWithHighestTotalPower()
        {
            var result = this.gladiators.OrderByDescending(g => g.GetTotalPower()).FirstOrDefault();

            return result;
        }

        public override string ToString()
        {
            //var result = new StringBuilder();

            return $"[{this.Name}] - [{Count}] gladiators are participating.";
        }
    }
}
