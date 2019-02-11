using System;
namespace _03.Odd__Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double oddSum = 0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenSum = 0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;
            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    evenSum += num;
                    if (evenMax < num)
                    {
                        evenMax = num;
                    }
                    if (evenMin > num)
                    {
                        evenMin = num;
                    }
                }
                else
                {
                    oddSum += num;
                    if (oddMax < num)
                    {
                        oddMax = num;
                    }
                    if (oddMin > num)
                    {
                        oddMin = num;
                    }
                }
            }
            Console.WriteLine($"OddSum={oddSum:f2},");
            Console.Write("OddMin=");
            if (oddMin != double.MaxValue)
            {
                Console.WriteLine($"{oddMin:f2},");
            }
            else
            {
                Console.WriteLine("No,");
            }
            Console.Write("OddMax=");
            if (oddMax != double.MinValue)
            {
                Console.WriteLine($"{oddMax:f2},");
            }
            else
            {
                Console.WriteLine("No,");
            }                  
            Console.WriteLine($"EvenSum={evenSum:f2},");
            Console.Write("EvenMin=");
            if (evenMin != double.MaxValue)
            {
                Console.WriteLine($"{evenMin:f2},");
            }
            else
            {
                Console.WriteLine("No,");
            }
            Console.Write("EvenMax=");
            if (evenMax != double.MinValue)
            {
                Console.WriteLine($"{evenMax:f2}");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
