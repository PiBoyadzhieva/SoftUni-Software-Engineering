using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    class Advanced : Player
    {
        private const int InitialHealthPoints = 250;

        public Advanced(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, InitialHealthPoints)
        {

        }
    }
}
