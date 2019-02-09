using System;
namespace _07.Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int oddSum = 0;
            int evenSum = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i%2==0)
                {
                    evenSum += num;
                }
                else
                {
                    oddSum += num;
                }
            }
            int diff = Math.Abs(evenSum - oddSum);
            if (diff==0)
            {
                Console.WriteLine($"Yes Sum = {evenSum}");
            }
            else
            {
                Console.WriteLine($"No Diff = {diff}");
            }
        }
    }
}
