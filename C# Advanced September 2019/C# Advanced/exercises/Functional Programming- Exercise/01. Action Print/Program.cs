using System;
using System.Collections.Generic;
using System.Linq;
namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = i => Console.WriteLine(string.Join(
                Environment.NewLine,i));
            var names = Console.ReadLine()
                .Split();
            print(names);

        }

 
    }
}
