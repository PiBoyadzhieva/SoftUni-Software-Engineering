using System;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException("Invalid input!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Invalid input!");
                }
                this.age = value;
            }
        }

        public string Gender
        {
            get => gender;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidOperationException("Invalid input!");
                }

                this.gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            var animalInfo = new StringBuilder();

            animalInfo.AppendLine($"{this.GetType().Name}")
                      .AppendLine($"{this.Name} {this.Age} {this.Gender}")
                      .AppendLine($"{this.ProduceSound()}");

            return animalInfo.ToString().TrimEnd();
        }
    }
}
