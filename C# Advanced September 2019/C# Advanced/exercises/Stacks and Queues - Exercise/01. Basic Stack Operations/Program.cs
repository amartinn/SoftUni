using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var n = numbers[0];
            var s = numbers[1];
            var x = numbers[2   ];
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < n; i++)
            {
                stack.Push(input[i]);
            }
            for (int i = 0; i < s; i++)
            {
                if (stack.Count>0)
                {
                    stack.Pop();
                }
                else
                {
                    break;
                }
            }
            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if(stack.Count>0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
