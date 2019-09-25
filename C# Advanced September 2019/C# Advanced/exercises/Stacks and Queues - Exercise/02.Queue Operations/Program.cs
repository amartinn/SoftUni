using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var n = numbers[0];
            var s = numbers[1];
            var x = numbers[2];
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(input[i]);
            }
            for (int i = 0; i < s; i++)
            {
                if (queue.Count > 0)
                {
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (queue.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count > 0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
