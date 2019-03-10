using System;
namespace _05.Fitness_Center
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalPeople = int.Parse(Console.ReadLine());
            int backCount = 0, chestCount = 0, legsCount = 0, absCount = 0, proteinShake = 0, proteinBar = 0;
            for (int i = 0; i < totalPeople; i++)
            {
                string activity = Console.ReadLine();
                switch (activity)
                {
                    case "Back":
                        {
                            backCount++;
                            break;
                        }
                    case "Chest":
                        {
                            chestCount++;
                            break;
                        }
                    case "Legs":
                        {
                            legsCount++;
                            break;
                        }
                    case "Abs":
                        {
                            absCount++;
                            break;
                        }
                    case "Protein shake":
                        {
                            proteinShake++;
                            break;
                        }
                    case "Protein bar":
                        {
                            proteinBar++;
                            break;
                        }
                }
            }
            double proteinShakePercent = (double)(proteinShake + proteinBar) / totalPeople;
            proteinShakePercent *= 100;
            Console.WriteLine($"{backCount} - back");
            Console.WriteLine($"{chestCount} - chest");
            Console.WriteLine($"{legsCount} - legs");
            Console.WriteLine($"{absCount} - abs");
            Console.WriteLine($"{proteinShake} - protein shake");
            Console.WriteLine($"{proteinBar} - protein bar");
            Console.WriteLine($"{100 - proteinShakePercent:f2}% - work out");
            Console.WriteLine($"{proteinShakePercent:f2}% - protein");
        }
    }
}
