using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthyHeaven
{
    public class Salad
    {
        private List<Vegetable> products;

        public string Name { get; private set; }

        public Salad(string name)
        {
            this.Name = name;
            this.products = new List<Vegetable>();
        }

        public int GetTotalCalories()
        {
            return this.products.Sum(p => p.Calories);
        }

        public int GetProductCount()
        {
            return this.products.Count();
        }

        public void Add(Vegetable product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine
                ($"* Salad {this.Name} is {this.GetTotalCalories()} calories and have {this.GetProductCount()} products:");

            foreach (var product in this.products)
            {
                result.AppendLine($"{product}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
