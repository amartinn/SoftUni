using System;
using System.Linq;
namespace _03._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];
                numbers[i] = Math.Round(numbers[i],MidpointRounding.AwayFromZero);
                
                Console.WriteLine($"{currentNumber} => {numbers[i]}");
            }
        }
    }
}
