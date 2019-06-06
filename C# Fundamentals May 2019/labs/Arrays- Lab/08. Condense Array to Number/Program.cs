using System;
using System.Linq;
namespace _08._Condense_Array_to_Number
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
            Console.WriteLine(numbers.Length);
            var current = new int[numbers.Length];
          for (int i = 0; i < numbers.Length-1; i++)
         {
        //      if (i + 1 >= numbers.Length)
        //      {
        //          break;
        //      }
        //      else
         //     {
                 current[i] = numbers[i] + numbers[i + 1];
              }
            // }
            foreach (var item in current)
            {
                Console.WriteLine(current);
            }
        }   
    }
}
