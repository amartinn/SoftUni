using System;
namespace _08.Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int fishQuota = int.Parse(Console.ReadLine());
            double asciSum = 0;
            int fishcount = 1;
            double money = 0;
            string fish = Console.ReadLine();
            while (fish!="Stop" )
            {
              
                double fishWeight = double.Parse(Console.ReadLine());
                for (int i = 0; i < fish.Length; i++)
                {
                    asciSum += fish[i];
                }
                asciSum /= fishWeight;
                if (fishcount%3==0)
                {
                    money += asciSum;
                }
                else
                {
                    money -= asciSum;
                }
                asciSum = 0;
                fishcount++;
                if (fishcount == fishQuota+1)
                {
                    Console.WriteLine("Lyubo fulfilled the quota!");
                    break;
                }
                fish = Console.ReadLine();
            }
            if (money>=0)
            {
                Console.WriteLine($"Lyubo's profit from {fishcount-1} fishes is {money:f2} leva.");
            }
            else
            {
                Console.WriteLine($"Lyubo lost {Math.Abs(money):f2} leva today.");
            }
        }
    }
}
