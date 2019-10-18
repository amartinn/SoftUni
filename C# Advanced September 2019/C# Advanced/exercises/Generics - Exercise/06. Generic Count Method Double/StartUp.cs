using System;
using System.Collections.Generic;

namespace _06_
{
    public class StartUp
    {
       public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var words = new List<double>();
            for (int i = 0; i < n; i++)
            {
                words.Add(double.Parse(Console.ReadLine()));
            }
            var targetItem = double.Parse(Console.ReadLine());
            var greaterNumbers = words.GreaterValue(targetItem);
            Console.WriteLine(greaterNumbers);
        }
    }
}
