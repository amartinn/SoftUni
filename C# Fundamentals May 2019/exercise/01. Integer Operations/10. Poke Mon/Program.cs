using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokemonPower = int.Parse(Console.ReadLine());
            double halfPokemonPower = pokemonPower / 2.0;
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());

            int pokedTargets = 0;
            while (pokemonPower >= distance)
            {   
                if (pokemonPower == halfPokemonPower)
                {
                    if (exhaustionFactor != 0)
                    {
                        pokemonPower /= exhaustionFactor;
                    }
                    if (pokemonPower >= distance)
                    {

                        pokemonPower -= distance;
                        pokedTargets++;
                    }

                }
                else
                {
                    pokemonPower -= distance;
                    pokedTargets++;
                }
            }
            Console.WriteLine(pokemonPower);
            Console.WriteLine(pokedTargets);
        }
    }
}

