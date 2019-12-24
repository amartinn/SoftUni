using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Even_or_Odd
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<int>> print = items => Console.WriteLine(string.Join(" ", items));
            Func<int, bool> isEven = x => x % 2 == 0;
            var bounds = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var command = Console.ReadLine();
            var lowerBound = bounds[0];
            var upperBound = bounds[1];
            var numbers = new List<int>();
            var result = new List<int>();
            for (int i = lowerBound; i <=upperBound; i++)
            {
                numbers.Add(i);
            }
            if (command=="even")
            {
                result = numbers.Where(isEven).ToList();
            }
            else
            {
                result = numbers.Where(x=>!isEven(x)).ToList();
            }
            print(result);
        }
    }
}
