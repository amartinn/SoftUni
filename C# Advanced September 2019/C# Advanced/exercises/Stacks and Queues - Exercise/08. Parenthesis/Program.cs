using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();
            var isBalanced = true;

            foreach (var parenthesis in input)
            {
                switch (parenthesis)
                {
                    case '[':
                    case '{':
                    case '(':
                        stack.Push(parenthesis);
                        break;
                    case '}':
                        if (!stack.Any())
                            isBalanced = false;

                        else if (stack.Pop() != '{')
                            isBalanced = false;
                        break;

                    case ')':
                        if (!stack.Any())
                            isBalanced = false;

                        else if (stack.Pop() != '(')
                            isBalanced = false;
                        break;

                    case ']':
                        if (!stack.Any())
                            isBalanced = false;

                        else if (stack.Pop() != '[')
                            isBalanced = false;
                        break;
                }
                if (!isBalanced)
                {
                    break;
                }
            }
            Console.WriteLine(isBalanced ? "YES":"NO");
          

           
        }
    }
}
