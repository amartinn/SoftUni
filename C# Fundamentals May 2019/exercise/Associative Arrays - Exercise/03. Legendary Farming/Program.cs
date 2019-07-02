using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            // motes , shards , fragments;
            Dictionary<string, int> materials = new Dictionary<string, int>();
        
            materials.Add("motes", 0);
            materials.Add("fragments", 0);
            materials.Add("shards", 0);
            var isThereLegendery = true;
            var winningMaterial = string.Empty;
            while (isThereLegendery)
            {
                var input = Console.ReadLine().ToLower().Split(" ").ToList();
                for (int i = 0; i < input.Count; i+=2)
                {
                    var quality = int.Parse(input[i]);
                    var item = input[i + 1];
                    if (!materials.ContainsKey(item))
                    {
                        materials[item] = 0;
                    }
                    materials[item] += quality;
                    if (materials[item]>=250)
                    {
                        materials[item] -= 250;
                        isThereLegendery = false;
                        winningMaterial = item;
                        break;
                    }
                }
            }
            var winningItem = itemObtained(winningMaterial);
            Console.WriteLine($"{winningItem} obtained!");
            //TODO
        }
        static string itemObtained(string item)
        {
            if (item=="shards")
            {
                return "Shadowmourne";
            }
            else if (item=="fragments")
            {
                return "Valanyr";
            }
            return "Dragonwrath";
        }

    }
}
