using System;
using System.Collections.Generic;
using System.Linq;

using FootballTeamGenerator.Exceptions;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;

        private Team()
        {
            players = new List<Player>();
        }
        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyNameException);
                }
                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if(this.players.Count == 0)
                {
                    return 0;
                }

                return (int)(Math.Round(this.players.Average(p => p.OverallSkill), 0));
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string name)
        {
            Player playerToRemove = this.players.FirstOrDefault(p => p.Name == name);

            if(playerToRemove == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MissingPlayerException, name, this.name));
            }

            this.players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
