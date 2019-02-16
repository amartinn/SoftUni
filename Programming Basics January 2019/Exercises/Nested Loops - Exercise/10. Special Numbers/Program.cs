using System;
namespace _10.Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int firstNum = 1; firstNum <= 9; firstNum++)
            {
                for (int secondNum = 1; secondNum <= 9; secondNum++)
                {
                    for (int thirdNum = 1; thirdNum <= 9; thirdNum++)
                    {
                        for (int forthNum = 1; forthNum <= 9; forthNum++)
                        {
                            if (number % firstNum == 0 && number % secondNum == 0 && number % thirdNum == 0 && number % forthNum == 0)
                            {
                                Console.Write($"{firstNum}{secondNum}{thirdNum}{forthNum} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
