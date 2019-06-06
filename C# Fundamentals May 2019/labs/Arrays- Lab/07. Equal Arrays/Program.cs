using System;
using System.Linq;
namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstArray = Console.ReadLine()
             .Split()
             .Select(int.Parse)
             .ToArray();
            var secondArray = Console.ReadLine()
             .Split()
             .Select(int.Parse)
             .ToArray();
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i]!=secondArray[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }
            var sum = 0;
            foreach (var number in firstArray)
            {
                sum += number;
            }
            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
