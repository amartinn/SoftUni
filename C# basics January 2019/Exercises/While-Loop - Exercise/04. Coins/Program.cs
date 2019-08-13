using System;
namespace _04.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal money = decimal.Parse(Console.ReadLine());

            int count = 0;
            if (money >= 2)
            {

                count = (int)(money / (decimal)2);
                money %= 2;
            }
            if (money >= 1)
            {
                money %= 1;
                count++;
            }
            if (money >= 0.5M)
            {
                money %= 0.50M;
                count++;
            }
            if (money >= 0.2M)
            {
                count += (int)(money / (decimal)0.2);
                money %= 0.20M;
            }
            if (money >= 0.1M)
            {
                money %= 0.10M;
                count++;
            }
            if (money >= 0.05M)
            {
                money %= 0.05M;
                count++;
            }
            if (money >= 0.02M)
            {   
                count += (int)(money / (decimal)0.02);
                money %= 0.02M;
            }
            if (money >= 0.01M)
            {
                money %= 0.01M;
                count++;
            }
            Console.WriteLine(count);
        }
    }
}
