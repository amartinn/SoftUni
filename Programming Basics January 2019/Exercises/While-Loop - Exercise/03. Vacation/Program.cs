using System;
namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double availablemoney = double.Parse(Console.ReadLine());
            string action = string.Empty;
            double money;
            int spendCount = 0;
            int daysCount = 0;
            while (availablemoney < moneyNeeded && spendCount < 5)
            {
                action = Console.ReadLine();
                money = double.Parse(Console.ReadLine());
                if (action == "spend")
                {
                    if (availablemoney <= money)
                    {
                        availablemoney = 0;
                    }
                    else
                    {
                        availablemoney -= money;
                    }
                    spendCount++;
                }
                else if (action == "save")
                {
                    spendCount = 0;
                    availablemoney += money;
                }
                daysCount++;
            }
            if (spendCount == 5)
            {
                Console.WriteLine($"You can't save the money.");
                Console.WriteLine(daysCount);
                return;
            }
            if (availablemoney >= moneyNeeded)
            {
                Console.WriteLine($"You saved the money for {daysCount} days.");
            }
        }
    }
}
