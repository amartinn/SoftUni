using System;
using System.Collections.Generic;
using System.Linq;
namespace _03._PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<string>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split();
                for (int j = 0; j < input.Length; j++)
                {
                    set.Add(input[j]);
                }
            }
            foreach (var element in set.OrderBy(x=>x))
            {
                Console.Write(element + " ");
            }
        }
    }
}
