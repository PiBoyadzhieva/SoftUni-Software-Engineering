using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<IRepair> repairs;
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<IRepair>();
        }

        public IReadOnlyCollection<IRepair> Repairs => this.repairs;

        public void AddRepair(IRepair repair)
        {
            this.repairs.Add(repair);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString()).AppendLine("Repairs:");

            foreach (var rep in Repairs)
            {
                sb.AppendLine($"  {rep.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
