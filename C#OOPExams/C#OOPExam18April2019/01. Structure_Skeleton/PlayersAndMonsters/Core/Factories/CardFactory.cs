using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            //Type cardType = Assembly.GetCallingAssembly()
            //    .GetTypes()
            //    .FirstOrDefault(x => x.Name.StartsWith(type));

            //ICard card = (ICard)Activator.CreateInstance(cardType, name);

            //return card;

            ICard card;

            switch (type)
            {

                case "Trap": card = new TrapCard(name);
                    break;
                case "Magic": card = new MagicCard(name);
                    break;

                default: card = null;
                    break;
            }

            return card;
        }
    }
}
