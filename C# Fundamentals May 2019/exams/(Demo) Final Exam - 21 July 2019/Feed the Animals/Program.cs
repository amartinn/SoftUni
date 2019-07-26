using System;
using System.Collections.Generic;
using System.Linq;

namespace Feed_the_Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO 70/100
            var input = string.Empty;
            var AnimalsAndFood = new Dictionary<string, int>();
            var areaAndCountOfHungryAnimals = new Dictionary<string, int>();
            while ((input=Console.ReadLine())!="Last Info")
            {
                var line = input.Split(":");
                var command = line[0];
                var animalName = line[1];
                var area = line[3];
                if (command == "Add")
                {
                    var dailyFoodLimit = int.Parse(line[2]);
                    if (!AnimalsAndFood.ContainsKey(animalName))
                    {
                        AnimalsAndFood[animalName] = 0;
                        if (!areaAndCountOfHungryAnimals.ContainsKey(area))
                        {
                            areaAndCountOfHungryAnimals[area] =1;
                        }
                        else
                        {
                            areaAndCountOfHungryAnimals[area] ++;
                        }
                        
                    }
                    AnimalsAndFood[animalName] += dailyFoodLimit;
                }

                else
                {
                    var food = int.Parse(line[2]);
                    if (AnimalsAndFood.ContainsKey(animalName))
                    {
                        AnimalsAndFood[animalName] -= food;
                        if (AnimalsAndFood[animalName] <= 0)
                        {
                            Console.WriteLine($"{animalName} was successfully fed");
                            AnimalsAndFood.Remove(animalName);
                            areaAndCountOfHungryAnimals[area]--;
                        }
                    }
                }
                
            }
                Console.WriteLine("Animals:");
                foreach (var animal in AnimalsAndFood.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{animal.Key} -> {animal.Value}g");
                }
                Console.WriteLine("Areas with hungry animals:");
                foreach (var areas in areaAndCountOfHungryAnimals.Where(x => x.Value > 0))
                {
                    Console.WriteLine($"{areas.Key} : {areas.Value} ");
                }

        }
    }
}
