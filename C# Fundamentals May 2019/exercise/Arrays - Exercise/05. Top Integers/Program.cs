using System;
using System.Linq;
namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var topIntegers = new int[numbers.Length];
            for (int i = 0; i <numbers.Length-1; i++)
            {
                var current = numbers[i];
                bool isTopInterger = true;
                for (int j = i+1; j < numbers.Length; j++)
                {
                    var otherNumber = numbers[j];
                    if (current<=otherNumber)
                    {
                        isTopInterger = false;
                        break;
                    }
                }
                if (isTopInterger)
                {
                    Console.Write(current + " ");
                }
            }
            Console.Write(numbers[numbers.Length-1]);
        }
    }
}
