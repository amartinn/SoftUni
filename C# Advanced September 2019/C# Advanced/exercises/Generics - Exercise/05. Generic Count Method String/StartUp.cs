using System;
using System.Collections.Generic;
namespace _05_
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var n = int.Parse(Console.ReadLine());
            var words = new List<string>();
            for (int i = 0; i < n; i++)
            {
                words.Add(Console.ReadLine());
            }
            var targetItem = Console.ReadLine();
            var greaterNumbers = words.GreaterValue(targetItem);
            Console.WriteLine(greaterNumbers);

        }
    }
}
