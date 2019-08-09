namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int InitialDamagePoints = 120;
        private const int InitialHealthPoint = 5;
        public TrapCard(string name)
            : base(name, InitialDamagePoints, InitialHealthPoint)
        {

        }
    }
}
