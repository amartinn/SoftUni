using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var currentCount = 1;
            var maxCount = 1;
            var number = numbers[0]; 

            for (int i = 1; i < numbers.Length; i++)
            {
                var previousNumber = numbers[i - 1];
                var currentNumber = numbers[i];
                if (previousNumber==currentNumber)
                {
                    currentCount++;
                    if (currentCount>maxCount)
                    {

                        maxCount = currentCount;
                        number = currentNumber;
                    }
                }
                else
                {
                    currentCount = 1;
                }
            }
            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}
