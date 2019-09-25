using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Max_Min_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>();
            var num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                var commandArgs = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                var command = commandArgs[0];
                switch (command)
                {
                    case 1:
                        stack.Push(commandArgs[1]);
                        break;
                    case 2:
                        if (stack.Count>0)
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        
                        break;
                    case 4:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }   
                        break;
                }
            }
            Console.WriteLine(string.Join(", ",stack));

        }
    }
}
