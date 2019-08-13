using System;
namespace _01.Tennis_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double tenisRocketPriceEach = double.Parse(Console.ReadLine());
            double tenisRocketsCount = double.Parse(Console.ReadLine());
            double sneakers = double.Parse(Console.ReadLine());
            double tenisRocketPrice = tenisRocketPriceEach * tenisRocketsCount;
            double pairOfSneakers = (tenisRocketPriceEach / 6)*sneakers;
            double otherEquipment = (tenisRocketPrice + pairOfSneakers) * 0.2;
            double total = tenisRocketPrice + pairOfSneakers + otherEquipment;
            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(total/8)}");
            double SevenEight = (double)7 / 8;
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(SevenEight*total)}");
           


        }
    }
}
