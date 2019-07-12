using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine().TrimStart(new char[] { '0' });
            int secondNumber = int.Parse(Console.ReadLine());
            if (secondNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }
            int reminder = 0;
            int multiply = 0;
            List<int> result = new List<int>();
            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                int currentDigit = firstNumber[i] - '0';
                multiply = currentDigit * secondNumber;
                multiply += reminder;
                result.Add(multiply % 10);
                reminder = multiply / 10;
            }
            if (reminder > 0)
            {
                result.Add(reminder);
            }
            result.Reverse();
            Console.WriteLine(string.Join("", result));
        }
    }
}