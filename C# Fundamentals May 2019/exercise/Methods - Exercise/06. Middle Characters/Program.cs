using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
        }
        static void Init()
        {
            var input = Console.ReadLine();
            bool IsEven = input.Length % 2 == 0;

            if (IsEven)
            {
                Console.WriteLine($"{input[(input.Length / 2) - 1]}{input[input.Length / 2]}");
            }
            else
            {
                Console.WriteLine($"{input[input.Length/2]}");
            }
        }
    }
}
