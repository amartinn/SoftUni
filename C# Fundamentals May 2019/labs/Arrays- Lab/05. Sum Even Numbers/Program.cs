using System;
using System.Linq;
namespace _05._Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]%2==0)
                {
                    sum += numbers[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
