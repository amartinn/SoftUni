using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = i => Console.WriteLine($"Sir {i}");
            var names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            names.ForEach(print);
                



        }
    }
}
