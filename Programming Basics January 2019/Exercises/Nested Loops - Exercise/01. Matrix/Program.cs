using System;
namespace _01._Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            for (int firstRowFirstNum = a; firstRowFirstNum <= b; firstRowFirstNum++)
            {
                for (int FirstRowSecondNum = a; FirstRowSecondNum <= b; FirstRowSecondNum++)
                {
                    for (int SecondRowFirstNum = c; SecondRowFirstNum <= d; SecondRowFirstNum++)
                    {
                        for (int SecondRowSecondNum = c; SecondRowSecondNum <= d; SecondRowSecondNum++)
                        {
                            if (firstRowFirstNum + SecondRowSecondNum == FirstRowSecondNum + SecondRowFirstNum && firstRowFirstNum != FirstRowSecondNum
                                && SecondRowFirstNum != SecondRowSecondNum)
                            {
                                Console.WriteLine($"{firstRowFirstNum}{FirstRowSecondNum}");
                                Console.WriteLine($"{SecondRowFirstNum}{SecondRowSecondNum}");
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
        }
    }
}
