using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Practice_Sessions
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            var RoadsAndRacers = new Dictionary<string, List<string>>();
            while ((input=Console.ReadLine())!="END")
            {
                var inputArgs = input.Split("->");
                var command = inputArgs[0];
                var road = inputArgs[1];
                if (command=="Add")
                {
                    if (!RoadsAndRacers.ContainsKey(road))
                    {
                        RoadsAndRacers[road] = new List<string>();
                    }
                    var racer = inputArgs[2];
                    RoadsAndRacers[road].Add(racer);
                }
                else if (command=="Move")
                {
                    var racer = inputArgs[2];
                    if (RoadsAndRacers[road].Contains(racer))
                    {
                        RoadsAndRacers[road].Remove(racer);
                        var nextRoad = inputArgs[3];
                        RoadsAndRacers[nextRoad].Add(racer);
                    }
                }
                else
                {
                    if (RoadsAndRacers.ContainsKey(road))
                    {
                        RoadsAndRacers.Remove(road);
                    }
                }
            }
            Console.WriteLine("Practice sessions:");
            foreach (var road in RoadsAndRacers.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {
                Console.WriteLine(road.Key);
                foreach (var racer in road.Value)
                {
                    Console.WriteLine($"++{racer}");
                }
            }
        }
    }
}
