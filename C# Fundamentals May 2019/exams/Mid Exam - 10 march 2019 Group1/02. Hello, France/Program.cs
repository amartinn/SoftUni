using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Hello__France
{
    class Program
    {
        static double budget;
        static void Main(string[] args)
        {
            var items = Console.ReadLine()
                .Split("|")
                .ToList();
            var broughtItems = new List<double>();
            var profitableItems = new List<double>();
            var budget = double.Parse(Console.ReadLine());
            Program.budget = budget;
            for (int i = 0; i < items.Count; i++)
            {
                var tokens = items[i].Split("->");
                var item = tokens[0];
                var price = double.Parse(tokens[1]);
                areItemsValid(item, price, broughtItems);
            }

            profitableItems = broughtItems.Select(x => x * 1.4).ToList();
            var profitSum = profitableItems.Sum();
            var sum = broughtItems.Sum();
            if (profitableItems.Count != 0)
            {
                for (int i = 0; i < profitableItems.Count; i++)
                {
                    Console.Write($"{profitableItems[i]:f2} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Profit: {profitSum-sum:f2}");
            if (Program.budget + profitSum >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
           

        }

        private static void areItemsValid(string item, double price, List<double> broughtItems)
        {
            
            if (item == "Clothes" && price <= 50 && budget-price>0)
            {
                budget -= price;
                broughtItems.Add(price);
            }
            else if (item == "Shoes" && price <= 35 && budget - price > 0)
            {
                budget -= price;
                broughtItems.Add(price);
            }
            else if (item == "Accessories" && price <= 20.5 && budget - price > 0)
            {
                budget -= price;
                broughtItems.Add(price);
            }
        }
    }
}
