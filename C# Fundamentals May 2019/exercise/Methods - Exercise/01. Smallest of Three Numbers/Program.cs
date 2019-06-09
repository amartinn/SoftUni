using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            SmallestOfThreeNumbers();
        }
        static void SmallestOfThreeNumbers()
        {
            var firstNumber = int.Parse(Console.ReadLine());
            var secondNumber = int.Parse(Console.ReadLine());
            var thirdNumber = int.Parse(Console.ReadLine());
            var result = 0;
            if (firstNumber<secondNumber && firstNumber<thirdNumber)
            {
                result = firstNumber;
            }
            else if (secondNumber<firstNumber &&secondNumber<thirdNumber)
            {
                result = secondNumber;
            }
            else
            {
                result = thirdNumber;
            }
            Console.WriteLine(result);
        }
    }
}
