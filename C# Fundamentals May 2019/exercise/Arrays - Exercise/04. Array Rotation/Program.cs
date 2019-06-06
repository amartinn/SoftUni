using System;
using System.Linq;
namespace _04._Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var rotation = int.Parse(Console.ReadLine());
            for (int i = 0; i < rotation; i++)
            {
                var firstElement = numbers[0];
                for (int j = 0; j < numbers.Length-1; j++)
                {
                    numbers[j] = numbers[j + 1];
                }
                
                numbers[numbers.Length -1] = firstElement;
            }
            Console.WriteLine(string.Join(" ",numbers));
              
        }
    }
}
