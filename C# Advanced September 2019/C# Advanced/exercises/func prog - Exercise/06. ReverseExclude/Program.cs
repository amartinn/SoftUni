using System;
using System.Linq;

namespace _06._ReverseExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var number = int.Parse(Console.ReadLine());
            Func<int,bool> exclude =  n => n % number != 0;
            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));
            numbers = numbers
                .Where(exclude)
                .Reverse()
                .ToArray();
            print(numbers);
        }
    }
}
