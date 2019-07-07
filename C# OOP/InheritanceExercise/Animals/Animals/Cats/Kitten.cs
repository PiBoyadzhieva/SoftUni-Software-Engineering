namespace Animals.Animals.Cats
{
    public class Kitten : Cat
    {
        private const string KittenDefaultGender = "female";
        public Kitten(string name, int age)
            : base(name, age, KittenDefaultGender)
        {
        }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
