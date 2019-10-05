using System;
using System.Collections.Generic;
using System.Linq;
namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var colorAndClothes = new Dictionary<string, Dictionary<string,int>>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var clothesArgs = Console.ReadLine()
                    .Split(" -> ");
                var color = clothesArgs[0];
                var clothes = clothesArgs[1].Split(",",StringSplitOptions.RemoveEmptyEntries);
                if (!colorAndClothes.ContainsKey(color))
                {
                    colorAndClothes[color] = new Dictionary<string, int>();
                }
                if (colorAndClothes.ContainsKey(color))
                {
                    for (int j = 0; j < clothes.Length; j++)
                    {
                        var currentCloth = clothes[j];
                        if (!colorAndClothes[color].ContainsKey(currentCloth))
                        {
                            colorAndClothes[color][currentCloth] = 1;
                        }
                        else
                        {
                            colorAndClothes[color][currentCloth]++;
                        }
                    }
                }
                
            }
            var clothAndColorToFind = Console.ReadLine().Split();
            var colorToFind = clothAndColorToFind[0];
            var clothToFind = clothAndColorToFind[1];
            foreach (var color in colorAndClothes)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    if (color.Key==colorToFind && cloth.Key==clothToFind)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                }
            }
        }
    }
}
