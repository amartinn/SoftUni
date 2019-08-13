using System;
namespace _06.Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            const int cakePrice = 45;
            const double wafflePrice = 5.80;
            const double pancakePrice = 3.20;
            int days = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());
            double sum = (cakes * cakePrice + waffles * wafflePrice + pancakePrice * pancakes) * workers;
            double totalSUm = sum * days;
            totalSUm -= totalSUm * 0.125;
            Console.WriteLine($"{totalSUm:f2}");
        }
    }
}
