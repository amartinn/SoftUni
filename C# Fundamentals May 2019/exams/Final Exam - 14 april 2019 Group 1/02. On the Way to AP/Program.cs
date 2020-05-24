using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._On_the_Way_to_AP
{
    class Program
    {
        static void Main(string[] args)
        {
            var storesAndItems = new Dictionary<string, List<string>>();
            var input = string.Empty;
            while ((input=Console.ReadLine())!="END")
            {
                var inputArgs = input.Split("->");
                var command = inputArgs[0];
                var store = inputArgs[1];
                if (command=="Add")
                {
                    if (!storesAndItems.ContainsKey(store))
                    {
                        storesAndItems[store] = new List<string>();
                    }
                    var items = inputArgs[2].Split(",");
                    for (int i = 0; i < items.Length; i++)
                    {
                        storesAndItems[store].Add(items[i]);
                    }
                }
                else if (command=="Remove")
                {
                    if (storesAndItems.ContainsKey(store))
                    {
                        storesAndItems.Remove(store);
                    }
                }
            }
            Console.WriteLine("Stores list:");
            foreach (var store in storesAndItems
                .OrderByDescending(x=>x.Value.Count)
                .ThenByDescending(x=>x.Key))
            {
                Console.WriteLine(store.Key);
                foreach (var item in store.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }
        }
    }
}
