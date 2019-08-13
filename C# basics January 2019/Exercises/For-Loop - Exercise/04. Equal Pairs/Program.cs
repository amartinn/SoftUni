using System;
namespace _04.Equal_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstNum = 0;
            int secondNum = 0;
            int previousSum = 0;
            int equal = 0;
            int sum = 0;
            int maxDif = int.MinValue;
            int diff = 0;
            for (int i = 1; i <= n; i++)
            {
                firstNum = int.Parse(Console.ReadLine());
                secondNum = int.Parse(Console.ReadLine());
                sum = firstNum + secondNum;
                if (sum==previousSum)
                {
                    equal++;
                }
                diff = Math.Abs(sum - previousSum);
              
                    if (i!=1 && maxDif<diff)
                    {
                    maxDif = diff;
                    }
                
                previousSum = sum;
            }
            if (equal==n-1)
            {
                Console.WriteLine($"Yes, value={sum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDif}");
            }
        }
    }
}
