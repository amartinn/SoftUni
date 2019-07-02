using System;
using System.Collections.Generic;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> products = new Dictionary<string, double>();
            var input = string.Empty;
            while ((input = Console.ReadLine())!="buy")
            {
                var tokens = input.Split();
                var product = tokens[0];
                var totalValue = double.Parse(tokens[1]) * double.Parse(tokens[2]);
                if (!products.ContainsKey(product))
                {
                    products.Add(product, 0.0);
                }
                products[product] += totalValue;
            }
            foreach (var kvp in products)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value:f2}");
            }
        }
    }
}
