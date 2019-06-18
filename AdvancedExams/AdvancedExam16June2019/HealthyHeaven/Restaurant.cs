using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private List<Salad> data;

        public string Name { get; private set; }

        public Restaurant(string name)
        {
            this.Name = name;
            this.data = new List<Salad>();
        }
        public void Add(Salad salad)
        {
            this.data.Add(salad);
        }
        public bool Buy(string name)
        {
            if (data.Any(x => x.Name == name))
            {
                this.data.Remove(this.data.FirstOrDefault(s => s.Name == name));
                return true;
            }

            return false;
        }
        public Salad GetHealthiestSalad()
        {
            return this.data.OrderBy(x => x.GetTotalCalories()).FirstOrDefault();
        }
        public string GenerateMenu()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this.Name} have {this.data.Count} salads:");

            foreach (var salad in this.data)
            {
                result.AppendLine($"{salad}");
            }

            return result.ToString().TrimEnd();
        }
    }
}