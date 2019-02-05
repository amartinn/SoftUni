using System;
namespace _02.Wedding_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            int price = count * 20;
            int dif = budget - price;
            if (dif >= 0)
                Console.WriteLine($"Yes! {Math.Round(dif * 0.4)} lv are for fireworks and {Math.Round(dif * 0.6)} lv are for donation.");
            else
                Console.WriteLine($"They won't have enough money to pay the covert. They will need {price - budget} lv more.");
        }
    }
}
