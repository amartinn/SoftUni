using System;
namespace _09.Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            int toyYears = 0;
            int moneyYears = 0;
            int money = 0;
            for (int i = 1; i <=age; i++)
            {
                if (i % 2 == 0)
                {  
                    moneyYears++;
                }
                else
                {
                    toyYears++;
                }
            }
            for (int i = 1; i <= moneyYears; i++)
            {
                money += 10 * i;
            }
            money += (toyYears * toyPrice) - moneyYears;
            double diff = Math.Abs(washingMachinePrice - money);
            if (money>=washingMachinePrice)
            {
                Console.WriteLine($"Yes! {diff:f2}");
            }   
            else
            {
                Console.WriteLine($"No! {diff:f2}");
            }
        }
    }
}
