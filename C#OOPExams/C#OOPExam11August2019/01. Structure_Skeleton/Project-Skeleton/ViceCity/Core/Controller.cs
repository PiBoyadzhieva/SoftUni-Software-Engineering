using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private const string MainPlayerName = "Vercetti";

        private readonly IPlayer mainPlayer;
        private readonly List<IPlayer> civilPlayers;
        private readonly IList<IGun> guns;
        private readonly INeighbourhood neighbourhood;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();
            this.neighbourhood = new GangNeighbourhood();
            this.guns = new List<IGun>();
        }

        public string AddPlayer(string name)
        {
            IPlayer civilPlayer = new CivilPlayer(name);

            this.civilPlayers.Add(civilPlayer);

            return $"Successfully added civil player: {civilPlayer.Name}!";
        }

        public string AddGun(string type, string name)
        {
            if(type != "Pistol" && type != "Rifle")
            {
                return "Invalid gun type!";
            }

            IGun gun = null;

            switch (type)
            {
                case "Rifle":
                    gun = new Rifle(name);
                    break;

                case "Pistol":
                    gun = new Pistol(name);
                    break;

                default:
                    break;
            }

            this.guns.Add(gun);

            return $"Successfully added {gun.Name} of type: {gun.GetType().Name}";
        }

        public string AddGunToPlayer(string name)
        {
            if(this.guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }

            var gun = guns[0];

            if (name == MainPlayerName)
            {
                this.mainPlayer.GunRepository.Add(gun);

                this.guns.RemoveAt(0);

                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            else if(!civilPlayers.Any(p => p.Name == name))
            {
                return "Civil player with that name doesn't exists!";
            }

            var civilPlayer = this.civilPlayers.FirstOrDefault(p => p.Name == name);

            civilPlayer.GunRepository.Add(gun);
            this.guns.RemoveAt(0);

            return $"Successfully added {gun.Name} to the Civil Player: {civilPlayer.Name}";
        }

        public string Fight()
        {
            this.neighbourhood.Action(this.mainPlayer, this.civilPlayers);

            bool areAllCivilPlayersAlive = this.civilPlayers
                .All(x => x.LifePoints == 50);

            var deadCivilPlayers = this.civilPlayers
                .Where(x => !x.IsAlive)
                .Count();

            if(areAllCivilPlayersAlive && this.mainPlayer.LifePoints == 100)
            {
                return "Everything is okay!";
            }

            else
            {
                var sb = new StringBuilder();

                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {deadCivilPlayers} players!");
                sb.AppendLine($"Left Civil Players: {this.civilPlayers.Where(x => x.IsAlive).Count()}!");

                string result = sb.ToString().TrimEnd();

                return result;
            }
        }
    }
}
