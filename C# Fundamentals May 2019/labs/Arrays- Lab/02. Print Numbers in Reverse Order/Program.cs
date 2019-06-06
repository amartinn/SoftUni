using System;
using System.Collections.Generic;
namespace _02._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
             Array.Reverse(numbers);
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}
