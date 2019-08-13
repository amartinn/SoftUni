using System;
namespace _06.Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            for (int firstNum = 1; firstNum <= first; firstNum++)
            {
                for (int secondNum = 1; secondNum <= second; secondNum++)
                {
                    for (int thirdNum = 1; thirdNum <= third; thirdNum++)
                    {
                        if (firstNum % 2 == 0 && thirdNum % 2 == 0)
                        {
                            if (secondNum == 2 || secondNum == 3 || secondNum == 5 || secondNum == 7)
                            {
                                Console.WriteLine($"{firstNum} {secondNum} {thirdNum}");
                            }
                        }
                    }
                }
            }
        }
    }
}
