using System;

namespace _01._The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            var daysOfTheAdventure = int.Parse(Console.ReadLine());
            var playersCount = int.Parse(Console.ReadLine());
            var energy = double.Parse(Console.ReadLine());
            var water = double.Parse(Console.ReadLine());
            var food = double.Parse(Console.ReadLine());
            var totalWater = daysOfTheAdventure * playersCount * water;
            var totalFood = daysOfTheAdventure * playersCount * food;
            for (int i = 1; i <=daysOfTheAdventure; i++)
            {
                         
                var energyLoss = double.Parse(Console.ReadLine());
                energy -= energyLoss;
                if (energy <= 0)
                {

                    break;
                }
                if (i%2==0)
                {
                    energy += energy * 0.05; ;
                    totalWater -= totalWater * 0.3; ;
                    
                }   
                 if (i%3==0)
                {
                    totalFood -= totalFood / playersCount;
                    energy += energy * 0.1; ;
                   
                }
            }
            if (energy>0)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {energy:f2} energy!");
                
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {totalFood:f2} food and {totalWater:f2} water.");
            }
        }
    }
}
