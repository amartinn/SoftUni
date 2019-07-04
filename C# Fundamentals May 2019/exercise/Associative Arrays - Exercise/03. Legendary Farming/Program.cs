using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static string itemObtained(string item)
        {
            if (item == "shards")
            {
                return "Shadowmourne";
            }
            else if (item == "fragments")
            {
                return "Valanyr";
            }
            return "Dragonwrath";
        }
        static void Main(string[] args)
        {
            var  validMaterials = new Dictionary<string, int>()
            {
                ["shards"] = 0,
                ["fragments"] = 0,
                ["motes"] = 0
            };
            var junkMaterials = new SortedDictionary<string, int>();
            
            var areMaterialsCollected = true;
            while (areMaterialsCollected)
            {
                var line = Console.ReadLine().ToLower().Split();
                for (int i = 0; i < line.Length - 1; i += 2)
                {
                    var material = line[i + 1];
                    var quantity = int.Parse(line[i]);
                    if (validMaterials.ContainsKey(material))
                        {
                        validMaterials[material] += quantity;

                        if (validMaterials[material] >=250 )
                        {
                            areMaterialsCollected = false;
                            
                            validMaterials[material] -= 250;
                            var item = string.Empty;
                            switch (material)
                            {
                                case "shards":
                                    {
                                        item = "Shadowmourne";
                                        break;
                                    }
                                case "fragments":
                                    {
                                        item = "Valanyr";
                                        break;
                                    }
                                case "motes":
                                    {
                                        item = "Dragonwrath";
                                        break;
                                    }
                            }
                            Console.WriteLine($"{item} obtained!");
                            break;
                        }
                        
                        }
                    else
                    {
                        if (!junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] = 0;
                        }
                        junkMaterials[material] += quantity;
                    }
                }
            }
            foreach (var material in validMaterials.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
            foreach (var item in junkMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }
 

    }
}
