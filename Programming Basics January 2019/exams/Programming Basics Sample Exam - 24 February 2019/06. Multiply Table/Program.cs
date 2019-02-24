using System;
namespace _06.Multiply_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int lastDigit = 0;
            int middleDigit = 0;
            int firstNum = 0;
            lastDigit = n / 100;
            n = n % 100;
            middleDigit = n / 10;
            n = n % 10;
            firstNum = n;
            for (int i = 1; i <= firstNum; i++)
            {
                for (int j = 1; j <= middleDigit; j++)
                {
                    for (int k = 1; k <=lastDigit; k++)
                    {
                        Console.WriteLine($"{i} * {j} * {k} = {i*j*k};");
                    }
                }
            }

        }
    }
}
