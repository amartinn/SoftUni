using System;
namespace _02.Maiden_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            double maidenPartyBudget = double.Parse(Console.ReadLine());
            int loveLetters = int.Parse(Console.ReadLine());
            int Candles = int.Parse(Console.ReadLine());
            int keyholder = int.Parse(Console.ReadLine());
            int caricatures = int.Parse(Console.ReadLine());
            int surprises = int.Parse(Console.ReadLine());
            double discount = 0;
            double sum = loveLetters * 0.6 + Candles * 7.2 + keyholder * 3.6 + caricatures * 18.2 + surprises * 22;
            int itemcount = loveLetters + Candles + keyholder + caricatures + surprises;
            if (itemcount >= 25)
            {
                discount = sum - sum * 0.35;


            }
            else
            {
                discount = sum;
            }

            double hosting = discount * 0.1;
            double winnings = discount - hosting;
            if (winnings >= maidenPartyBudget)
            {
                Console.WriteLine($"Yes! {winnings - maidenPartyBudget:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {maidenPartyBudget - winnings:f2} lv needed.");
            }
        }
    }
}
