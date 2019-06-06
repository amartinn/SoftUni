using System;
using System.Linq;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var uniqueNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];
                for (int j = i+1; j < numbers.Length; j++)
                {
                    var secondNumber = numbers[j];
                    if (currentNumber+secondNumber == uniqueNumber)
                    {
                        Console.WriteLine($"{currentNumber} {secondNumber}");
                    }
                }
            }
        }
    }
}
