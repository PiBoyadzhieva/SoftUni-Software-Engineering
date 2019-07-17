namespace WildFarm.Models.Animals.Entities
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livngRegion, string breed) 
            : base(name, weight, livngRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }
        public override string ToString()
        {
            return base.ToString() + $"{this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
