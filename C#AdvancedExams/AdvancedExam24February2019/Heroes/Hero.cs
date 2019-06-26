using System.Text;

namespace Heroes
{
    public class Hero
    {
        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public Item Item { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"Hero: {this.Name} – {this.Level}lvl");
            result.AppendLine("Item:");
            result.AppendLine($"  * Strength: {Item.Strength}");
            result.AppendLine($"  * Ability: {Item.Ability}");
            result.AppendLine($" * Intelligence: {Item.Intelligence}");

            return result.ToString().TrimEnd();
        }
    }
}
