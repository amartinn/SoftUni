using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicate
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = 1;
            var end = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var output = new List<int>();
            for (int i =start; i <=end; i++)
            {
                var isDivisible = true;
                foreach (var num in numbers)
                {
                    if (i%num != 0)
                    {
                        isDivisible = false;
                        continue;
                    }
                }
                if (isDivisible)
                {
                    output.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ",output));
        }
    }
}
