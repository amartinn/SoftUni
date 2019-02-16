using System;
namespace _03.Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string number1 = number.ToString();
            int Lenght = number1.Length;
            char current;
            int lastNum;
            for (int i = 0; i < Lenght; i++)
            {
                lastNum = number % 10;
                if (lastNum == 0)
                {
                    Console.Write("ZERO");
                }
                for (int j = 0; j < lastNum; j++)
                {
                    current = (char)(lastNum + 33);
                    Console.Write($"{current}");
                }
                Console.WriteLine();
                number = number / 10;
            }
        }
    }
}
