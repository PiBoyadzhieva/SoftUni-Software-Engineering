using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            //Type playerType = Assembly.GetCallingAssembly()
            //    .GetTypes()
            //    .FirstOrDefault(x => x.Name == type);

            //IPlayer player = (IPlayer)Activator.CreateInstance(playerType, new CardRepository(), username);

            //return player;

            IPlayer player;

            switch (type)
            {
                case "Beginner":
                    player = new Beginner(new CardRepository(), username);
                    break;

                case "Advanced":
                    player = new Advanced(new CardRepository(), username);
                    break;

                default:
                    player = null;
                    break;
            }

            return player;
        }
    }
}
