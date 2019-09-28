using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfOperations = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();
            var text = string.Empty;
            for (int i = 0; i < numberOfOperations; i++)
            {
                var commandArgs = Console.ReadLine()
                    .Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
                var command = int.Parse(commandArgs[0]);
                switch (command)
                {

                    case 1:
                        var charsToAdd = commandArgs[1];
                        text += charsToAdd;
                        stack.Push(text);
                        break;
                    case 2:
                        var charsToErase = int.Parse(commandArgs[1]);
                        text = text.Substring(0, text.Length - charsToErase);
                        stack.Push(text);
                        break;
                    case 3:
                        var index = int.Parse(commandArgs[1]);
                        Console.WriteLine(text[index-1]);
                        break;
                    case 4:
                        stack.Pop();
                        if (stack.Count>0)
                        {
                            text = stack.Peek();
                        }
                        else
                        {
                            text = string.Empty;    
                        }
                         break;
                }
            }
   
        }
    }
}
