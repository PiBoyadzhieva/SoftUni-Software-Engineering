namespace WildFarm.Models.Animals.Entities
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livngRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livngRegion;
        }

        public string LivingRegion { get; private set; }
    }
}
