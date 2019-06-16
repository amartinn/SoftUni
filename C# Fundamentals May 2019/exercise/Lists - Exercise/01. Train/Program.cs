using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            var wagons = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var maxCapacity = int.Parse(Console.ReadLine());
           
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0]=="end")
                {
                    Console.WriteLine(string.Join(" ",wagons));
                    return;
                }
                if (input.Length == 2)
                {
                    var value = int.Parse(input[1]);
                    wagons.Add(value);
                }
                else
                {
                    var value = int.Parse(input[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i]+value<=maxCapacity)
                        {
                            wagons[i] += value;
                            break;
                        }
                    }
                }

            }
            
        }
    }
}
