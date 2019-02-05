using System;   
namespace _04.Wedding_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string item = Console.ReadLine();
            double price = 0;
            int balloonsCount = 0;
            int flowersCount = 0;
            int candlesCount = 0;
            int ribbonCount = 0;
            double SavedBudget = budget;
            while (item != "stop")
            {
                int countOfItems = int.Parse(Console.ReadLine());
                switch (item)
                {
                    case "balloons":
                        {
                            price = countOfItems * 0.1; balloonsCount += countOfItems; break;
                        }
                    case "flowers":
                        {
                            price = countOfItems * 1.5; flowersCount += countOfItems; break;
                        }
                    case "candles":
                        {
                            price = countOfItems * 0.5; candlesCount += countOfItems; break;
                        }
                    case "ribbon":
                        {
                            price = countOfItems * 2; ribbonCount += countOfItems; break;
                        }
                }

                if (budget >= 0)
                {
                    budget -= price;
                }
                if (budget <= 0)
                {
                    Console.WriteLine($"All money is spent!");
                    break;
                }
                item = Console.ReadLine();
            }
            if (item == "stop")
            {
                double moneyspend = SavedBudget - budget;
                Console.WriteLine($"Spend money: {moneyspend:f2}");
                Console.WriteLine($"Money left: {budget:f2}");
            }
            Console.WriteLine($"Purchased decoration is {balloonsCount} balloons, {ribbonCount} m ribbon," +
                $" {flowersCount} flowers and {candlesCount} candles.");
        }
    }
}
