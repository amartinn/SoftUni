using System;
using System.Collections.Generic;
namespace _02._A_Miner_Task
{
    class Program
    { 
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            var input = string.Empty;
            while ((input=Console.ReadLine())!="stop")
            {
               ;
                var resource = input;
                var quality = int.Parse(Console.ReadLine());
                if (!resources.ContainsKey(resource))
                {
                    resources[resource] = 0;
                }
                resources[resource] += quality;

            }
            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
