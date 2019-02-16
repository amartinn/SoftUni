using System;
namespace _06.Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            int x = 0;
            int sumPrime = 0;
            int sumNonPrime = 0;
            bool isPrime = true;
            while (input != "stop")
            {
                Int32.TryParse(input, out x);
                isPrime = true;
                if (x < 0)
                {
                    Console.WriteLine("Number is negative.");
                    x = 0;
                }
                if (x == 1)
                {
                    isPrime = false;
                }
                else
                {
                    for (int i = x; i >= 2; i--)
                    {
                        if (x % i == 0 && i != x)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }
                if (isPrime)
                {
                    sumPrime += x;
                }
                else
                {
                    sumNonPrime += x;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrime}");
        }
    }
}
