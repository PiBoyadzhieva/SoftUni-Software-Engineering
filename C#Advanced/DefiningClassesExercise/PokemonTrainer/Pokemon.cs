using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Pokemon
    {
        public Pokemon(string name, string elelement, int health)
        {
            this.Name = name;
            this.Element = elelement;
            this.Health = health;
        }
        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}
