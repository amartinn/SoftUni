using System;
using System.Linq;

namespace _05._Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
      
            var command = string.Empty;
            Func<int, int> add = n => n + 1;
            Func<int, int> multiply = n => n*2;
            Func<int, int> subtract = n => n - 1;
            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));
            while ((command=Console.ReadLine())!="end")
            {
                if (command=="add")
                {
                    numbers = numbers
                        .Select(add)
                        .ToArray();
                }
                else if (command=="multiply")
                {
                    numbers = numbers
                       .Select(multiply)
                       .ToArray();
                }
                else if (command== "subtract")
                {
                    numbers = numbers
                       .Select(subtract)
                       .ToArray();
                }
                else
                {
                    print(numbers);
                }
            }
        }
    }
}
