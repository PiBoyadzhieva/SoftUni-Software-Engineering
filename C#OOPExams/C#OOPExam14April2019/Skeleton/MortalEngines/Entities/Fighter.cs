using MortalEngines.Entities.Contracts;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double initialHealthPoints = 200;
        private const int InitialAttack = 50;
        private const int InitialDefense = 25;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, 
                  attackPoints + InitialAttack,
                  defensePoints - InitialDefense, 
                  initialHealthPoints)
        {
            this.AggressiveMode = true;

            //this.ToggleAggressiveMode(); Another way to set correctly attackPoints and DefencePoints instead to pass values top;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if(AggressiveMode == true)
            {
                this.AttackPoints -= InitialAttack;
                this.DefensePoints += InitialDefense;
                AggressiveMode = false;
            }

            else if (AggressiveMode == false)
            {
                this.AttackPoints += InitialAttack;
                this.DefensePoints -= InitialDefense;
                AggressiveMode = true;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Aggressive: {(this.AggressiveMode == true ? "ON" : "OFF")}");

            string result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
