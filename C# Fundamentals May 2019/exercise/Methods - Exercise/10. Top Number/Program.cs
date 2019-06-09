using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            Init();

        }
        static void Init()
        {

            var number = int.Parse(Console.ReadLine());
            PrintResult(number);
        }
        static void PrintResult(int number)
        {
            for (int i = 1; i <=number; i++)
            {
                if (IsItDivisibleByEight(i) && IsItEvenNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
       static bool IsItDivisibleByEight(int number)
        {
            var currentNumber = number;
            var sum = 0;
            while (currentNumber>0)
            {
                var lastDigit = currentNumber % 10;
                sum += lastDigit;
                currentNumber /= 10;
            }
            if (sum%8==0)
            {
                return true;
            }
            return false;
        }
       static bool IsItEvenNumber(int number)
        {
            var currentNumber = number;
            while (currentNumber > 0)
            {


                var lastDigit = currentNumber % 10;
                if (lastDigit % 2 != 0)
                {
                    return true;
                }
                currentNumber /= 10;
            }
            return false;

        }
    }
}
