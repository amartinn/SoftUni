using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishman = int.Parse(Console.ReadLine());
            double result = 0;
            switch (season)
            {
                case "Spring":
                    {
                        result = 3000;
                        break;
                    }
                case "Summer":
                case "Autumn":
                    {
                        result = 4200;
                        break;
                    }
                case "Winter":
                    {
                        result = 2600;
                        break;
                    }
            }
            if (fishman <= 6)
            {
                result -= result * 0.1;
            }
            else if (fishman > 7 && fishman <= 11)
            {
                result -= result * 0.15;
            }
            else
            {
                result -= result * 0.25;
            }
            if (fishman % 2 == 0 && season != "Autumn")
            {
                result -= result * 0.05;
            }
            if (budget >= result)
            {
                Console.WriteLine($"Yes! You have {budget - result:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {result - budget:f2} leva.");
            }
        }
    }
}
