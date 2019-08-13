using System;
namespace _06.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            double moneyNeeded = 0;
            double moneySaved = 0;
            double storedmoney = 0;
            while (destination!="End")
            {
                moneyNeeded = double.Parse(Console.ReadLine());
                while (moneyNeeded>storedmoney)
                {
                    moneySaved = double.Parse(Console.ReadLine());
                    storedmoney += moneySaved;
                    
                }
                Console.WriteLine($"Going to {destination}!");
                destination = Console.ReadLine();
                storedmoney = 0;
                
            }
           
        }
    }
}
