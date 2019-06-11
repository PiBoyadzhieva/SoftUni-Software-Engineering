using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Tournament")
                {
                    break;
                }

                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]); ;

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                trainers[trainerName].Pokemons.Add(pokemon);
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.FindIndex(n => n.Element == command) < 0)
                    {
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                    }
                    else
                    {
                        trainer.Value.Badges++;
                    }

                    var tempPokemons = new List<Pokemon>(trainer.Value.Pokemons);

                    foreach (var pokemon in tempPokemons)
                    {
                        if (pokemon.Health <= 0)
                        {
                            trainer.Value.Pokemons.Remove(pokemon);
                        }
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(n => n.Value.Badges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
