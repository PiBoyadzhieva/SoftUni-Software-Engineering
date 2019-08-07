using MortalEngines.Entities.Contracts;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double initialHealthPoints = 100;
        private const int InitialAttack = 40;
        private const int InitialDefense = 30;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name,
                  attackPoints - InitialAttack,
                  defensePoints + InitialDefense,
                  initialHealthPoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode == true)
            {
                this.AttackPoints += InitialAttack;
                this.DefensePoints -= InitialDefense;
                DefenseMode = false;
            }

            else if (DefenseMode == false)
            {
                this.AttackPoints -= InitialAttack;
                this.DefensePoints += InitialDefense;
                DefenseMode = true;
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Defense: {(this.DefenseMode == true ? "ON" : "OFF")}");

            string result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
