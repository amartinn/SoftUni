using System;
using System.Linq;
namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var leftSum = 0;
            var rightSum = numbers.Sum();

            for (int i = 0; i < numbers.Length; i++)
            {
                rightSum -= numbers[i];
                if (leftSum==rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
                leftSum += numbers[i];
            }
            Console.WriteLine("no");
        }
    }
}
