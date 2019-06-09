using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
        }
        static void Init()
        {
            var firstNumber = double.Parse(Console.ReadLine());
            var secondNumber = double.Parse(Console.ReadLine());
            Console.WriteLine($"{(CalculateFactorial(firstNumber) / CalculateFactorial(secondNumber)):f2}");
        }
        static double CalculateFactorial(double number)
        {
            var factorial = 1.0;
            for (double i = number; i >= 1; i--)
            {
                 factorial *= i;
            }
            return factorial;
        }
    }
}
