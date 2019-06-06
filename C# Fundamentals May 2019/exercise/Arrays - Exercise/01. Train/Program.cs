using System;
using System.Linq;
using System.Collections.Generic;
namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            var wagonCount = int.Parse(Console.ReadLine());
            var wagons = new int[wagonCount];
            for (int i = 0; i < wagonCount; i++)
            {
                var currentPeopleInWagon = int.Parse(Console.ReadLine());
                wagons[i] = currentPeopleInWagon;
            }
            var sum = wagons.Sum();
            Console.WriteLine(string.Join(" ",wagons));
            Console.WriteLine(sum);
        }
    }
}
