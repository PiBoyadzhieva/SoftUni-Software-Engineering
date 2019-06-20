using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }
        
        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            this.data.Remove(this.data.FirstOrDefault(h => h.Name == name));
        }

        public Hero GetHeroWithHighestStrength()
        {
            //int maxStrength = this.data.Max(h => h.Item.Strength);
            //return this.data.FirstOrDefault(h => h.Item.Strength == maxStrength);

            var result = this.data.OrderByDescending(h => h.Item.Strength).FirstOrDefault();

            return result;
        }

        public Hero GetHeroWithHighestAbility()
        {
            var result = this.data.OrderByDescending(h => h.Item.Ability).FirstOrDefault();

            return result;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            var result = this.data.OrderByDescending(h => h.Item.Intelligence).FirstOrDefault();

            return result;
        }

        public int Count => this.data.Count;

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var hero in this.data)
            {
                result.AppendLine(hero.ToString());
                //result.AppendLine($"{hero}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
