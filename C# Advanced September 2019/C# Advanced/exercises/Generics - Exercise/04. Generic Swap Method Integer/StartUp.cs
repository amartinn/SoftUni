using System;
using System.Collections.Generic;

namespace _04_
{
   public class StartUp
    {
        public static void Main(string[] args)
        {

            var n = int.Parse(Console.ReadLine());
            var numbers = new List<int>();
            for (int i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());
                numbers.Add(number);
            }


            var indexes = Console.ReadLine()
                .Split();
            var firstIndex = int.Parse(indexes[0]);
            var secondIndex = int.Parse(indexes[1]);

            var box = new Box<int>(numbers);
            box.Swap(firstIndex, secondIndex);
            box.PrintList();
        }
    }
}
