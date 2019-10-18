using System;
using System.Collections.Generic;

namespace _03_
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var words = new List<string>();
            for (int i = 0; i < n; i++)
            {
                var word = Console.ReadLine();
                words.Add(word);
            }
           

            var indexes = Console.ReadLine()
                .Split();
            var firstIndex = int.Parse(indexes[0]);
            var secondIndex = int.Parse(indexes[1]);

            var box = new Box<string>(words);
            box.Swap(firstIndex, secondIndex);
            box.PrintList();

        }
       
    }
}
