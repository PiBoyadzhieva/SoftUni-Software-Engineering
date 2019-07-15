using FoodShortage.Contracts;

namespace FoodShortage.Models
{
    public abstract class Person : IBuyer
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Food = 0;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Food { get; protected set; }
        public abstract void BuyFood();
    }
}
