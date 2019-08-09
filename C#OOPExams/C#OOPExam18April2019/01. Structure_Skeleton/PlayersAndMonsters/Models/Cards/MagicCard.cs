namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int InitialDamagePoints = 5;
        private const int InitialHealthPoint = 80;
        public MagicCard(string name) 
            : base(name, InitialDamagePoints, InitialHealthPoint)
        {

        }
    }
}
