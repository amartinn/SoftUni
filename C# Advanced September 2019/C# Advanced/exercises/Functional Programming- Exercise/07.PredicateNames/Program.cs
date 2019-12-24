using System;
using System.Linq;

namespace _07.PredicateNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
           Func<string,bool> predicate = name => name.Length <= number;
            Console.ReadLine()
                 .Split()
                 .Where(predicate)
                 .ToList()
                 .ForEach(n => Console.WriteLine(n));
        }
    }
}
