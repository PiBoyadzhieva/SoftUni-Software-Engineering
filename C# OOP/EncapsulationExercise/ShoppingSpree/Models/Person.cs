using System.Collections.Generic;
using System;

using ShoppingSpree.Exceptions;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;

        private Person()
        {
            this.bag = new List<Product>();
        }
        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;
        }
        public string Name
        {
            get => this.name;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NullOrEmptyNameException);
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;

            set
            {
                if (money < 0)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeMoneyException);
                }
                this.money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            decimal moneyLeft = this.Money - product.Cost;

            if (moneyLeft < 0)
            {
                throw new InvalidOperationException(String.Format
                    (ExceptionMessages.CannotAffordAProductException, this.Name, product.Name));
            }

            this.money = moneyLeft;
            this.bag.Add(product);
        }

        public override string ToString()
        {
            if(this.bag.Count == 0)
            {
                return $"{this.Name} - Nothing bought";
            }

            return $"{this.Name} - {string.Join(", ", bag)}";
        }
    }
}
