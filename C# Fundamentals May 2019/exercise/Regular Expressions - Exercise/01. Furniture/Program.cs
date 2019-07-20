using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @">>([A-Za-z\s]+)<<(\d+(.\d+)?)!(\d+)";
            var regex = new Regex(pattern);
            var input = string.Empty;
            var furniture = new List<string>();
            var totalPrice = 0.0;
            while ((input=Console.ReadLine())!="Purchase")
            {
                Match match = regex.Match(input);
                if (match.Success)
                {

                    var currentFurniture = match.Groups[1].Value;
                    var currentPrice = double.Parse(match.Groups[2].Value);
                    var quantity = int.Parse(match.Groups[4].Value);
                    furniture.Add(currentFurniture);
                    totalPrice += currentPrice * quantity;
                }
            }
            if (furniture.Count==0)
            {
                return;
            }
            Console.WriteLine("Bought furniture:");
            Console.WriteLine(string.Join(Environment.NewLine,furniture));
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
