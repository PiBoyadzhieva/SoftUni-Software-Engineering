using System;

using SoftUniRestaurant.Models.Foods.Contracts;

namespace SoftUniRestaurant.Models.Foods
{
    public abstract class Food : IFood
    {
        private string name;
        private int servingSize;
        private decimal price;

        protected Food(string name, int servingSize, decimal price)
        {
            this.Name = name;
            this.ServingSize = servingSize;
            this.Price = price;
        }

        public string Name
        {
            get => name;

            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space!");
                }
                name = value;
            }
        }
        public int ServingSize
        {
            get => servingSize;

            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Serving size cannot be less or equal to zero");
                }
                servingSize = value;
            }
        }
        public decimal Price
        {
            get => price;

            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Price cannot be less or equal to zero!");
                }
                price = value;
            }
        }

        public override string ToString()
        {
            return $"{this.name}: {this.servingSize}g - {this.price:f2}";
        }
    }
}
