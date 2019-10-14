using System;
using System.Linq;

namespace _03._Create_Min_Func
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> min = inputNumbers =>
             {
                 int minValue = int.MaxValue;
                 foreach (var currentNumber in inputNumbers)
                 {
                     if (currentNumber<minValue)
                     {
                         minValue = currentNumber;
                     }
                 }
                 return minValue;
             };
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var result = min(input);
            Console.WriteLine(result);
        }
    }
}
