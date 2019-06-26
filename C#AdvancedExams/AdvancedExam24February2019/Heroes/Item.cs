using System.Text;

namespace Heroes
{
    public class Item
    {
        public Item(int strength, int ability, int intelligence)
        {
            this.Strength = strength;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }
        public int Strength { get; private set; }
        public int Ability { get; private set; }
        public int Intelligence { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Item: ");
            result.AppendLine($"  * Strength: {this.Strength}");
            result.AppendLine($"  * Ability: {this.Ability}");
            result.AppendLine($"  * Intelligence: {this.Intelligence}");

            return result.ToString().TrimEnd();
        }
    }
}
