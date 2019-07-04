using System;
using System.Collections.Generic;

namespace _04._Orderss
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, List<double>>();
            var input = string.Empty;
            while ((input=Console.ReadLine())!="buy")
            {
                var line = input.Split();
                var product = line[0];
                var price = double.Parse(line[1]);
                var quantity = double.Parse(line[2]);
                if (!products.ContainsKey(product))
                {
                    products[product] = new List<double>();
                    products[product].Add(price);
                    products[product].Add(quantity);
                }
                else
                {
                    products[product][1] += quantity;
                    if (products[product][0]!=price)
                    {
                        products[product][0] = price;
                    }
                }
            }
            foreach (var product in products)
            {
                    
                Console.WriteLine($"{product.Key} -> {product.Value[1]*product.Value[0]:f2}");
            }

        }
    }
}
