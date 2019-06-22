using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }
        public string Name { get; private set; }
        public Stat Stat { get; private set; }
        public Weapon Weapon { get; private set; }

        public int GetTotalPower()
        {
            return GetWeaponPower() + GetStatPower();
        }
        public int GetWeaponPower()
        {
            int sum = this.Weapon.Solidity + this.Weapon.Sharpness + this.Weapon.Size;

            return sum;
        }
        public int GetStatPower()
        {
            int sum = this.Stat.Skills + this.Stat.Agility + this.Stat.Flexibility + this.Stat.Strength
                + this.Stat.Intelligence;

            return sum;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"[{this.Name}] - [{GetTotalPower()}]");
            result.AppendLine($"  Weapon Power: [{GetWeaponPower()}]");
            result.AppendLine($"  Stat Power: [{GetStatPower()}]");

            return result.ToString().TrimEnd();
        }
    }
}
