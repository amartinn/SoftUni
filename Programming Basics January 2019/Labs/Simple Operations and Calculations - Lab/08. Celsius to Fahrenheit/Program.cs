using System;

namespace _08.Celsius_to_Fahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            double c = double.Parse(Console.ReadLine());
            double f = (c * 9) / 5 + 32;
            Console.WriteLine($"{f:f2}");
        }
    }
}
