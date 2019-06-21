using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Seize_the_Fire
{
    class Program
    {
        static void Main(string[] args)
        {
            var levelOfFire = Console.ReadLine()
                .Split("#")
                .ToList();
            var totalWater = double.Parse(Console.ReadLine());
            var effort = 0.0;
            var totalFire = 0.0;
            var puttedOutCells = new List<int>();
            //High = 89#    Low = 28#   Medium = 77#Low = 23
            for (int i = 0; i < levelOfFire.Count; i++)
            {
                var splittedInput = levelOfFire[i].Split(" ");
                var level = splittedInput[0];
                var value = int.Parse(splittedInput[2]);
                if (totalWater<=0)
                {
                    break;
                }
                if (level=="High" && value>=81 && value<=125)
                {
                    if (totalWater>=value)
                    {
                        totalWater -= value;
                        effort += value * 0.25;
                        puttedOutCells.Add(value);
                    }
                }
                else if (level=="Medium" && value>=51 && value<=80)
                {
                    if (totalWater >= value)
                    {
                        totalWater -= value;
                        effort += value * 0.25;
                        puttedOutCells.Add(value);
                    }
                }
                else if (level=="Low" && value>=1 && value<=50)
                {
                    if (totalWater >= value)
                    {
                        totalWater -= value;
                        effort += value * 0.25;
                        puttedOutCells.Add(value);
                    }
                }
            }
            Console.WriteLine("Cells:");
            foreach (var cell in puttedOutCells)
            {
                Console.WriteLine($" - {cell}");
                totalFire += cell;
            }
            Console.WriteLine($"Effort: {effort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");
            //High	81 - 125
            //Medium  51 - 80
            //Low 1 - 50    


        }
    }
}