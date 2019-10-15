using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
   public class StartUp
    {
        public static void Main(string[] args)
        {

            var trainers = new Dictionary<string, Trainer>();
            var command = string.Empty;
            while ((command=Console.ReadLine())!= "Tournament")
            {
                var trainerAndPokemonInfo = command
                    .Split();

                var trainerName = trainerAndPokemonInfo[0];
                var pokemonName = trainerAndPokemonInfo[1];
                var pokemonElement = trainerAndPokemonInfo[2];
                var pokemonHealth = int.Parse(trainerAndPokemonInfo[3]);
                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                var trainer = new Trainer(trainerName);
                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = trainer;
                }
                trainers[trainerName].Pokemons.Add(pokemon);
               
            }
            while ((command = Console.ReadLine()) != "End")
            {
                var element = command;
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(p=>p.Element==element))
                    {
                        trainer.Value.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                        trainer.Value.Pokemons.RemoveAll(x => x.Health <= 0);

                    }
                }
            }
            foreach (var trainer in trainers.OrderByDescending(x=>x.Value.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.NumberOfBadges} {trainer.Value.Pokemons.Count}");
            }

        }
    }
}
