using System;

namespace _01._Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int forthNumber = int.Parse(Console.ReadLine());
            int result = firstNumber + secondNumber;
            result /= (int)thirdNumber;
            result *= forthNumber;
            Console.WriteLine(result);
        }
    }
}