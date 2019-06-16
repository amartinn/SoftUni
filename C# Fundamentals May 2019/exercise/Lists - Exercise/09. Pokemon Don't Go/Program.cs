using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            var pokemons = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToList();
            List<long> removedElements = new List<long>();
            while (pokemons.Count>0)
            {   
                var index = int.Parse(Console.ReadLine());
                long currentNum = -1;
                if (index<0)
                {
                    pokemons.RemoveAt(0);
                    pokemons.Insert(0, pokemons.Last());
                     currentNum = pokemons[0];
                   
                }
                else if (index>=pokemons.Count)
                {
                    currentNum = pokemons[0];
                    pokemons.RemoveAt(pokemons.Count - 1);
                    pokemons.Add(currentNum);  
                }
                else
                {
                    currentNum = pokemons[index];
                    pokemons.RemoveAt(index);

                }
                removedElements.Add(currentNum);
                IncreaseAndDecrease(pokemons, currentNum);
            }
            long sum = 0;
            foreach (var element in removedElements)
            {
                sum += element;
            }
            Console.WriteLine(sum);

            
        }
        static List<long> IncreaseAndDecrease(List<long> pokemons,long currentNum)
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                if (currentNum>=pokemons[i])
                {
                    pokemons[i] += currentNum;
                }
                else
                {
                    pokemons[i] -= currentNum;
                }
            }
            return pokemons;
        }
       
       
        
    }
}
