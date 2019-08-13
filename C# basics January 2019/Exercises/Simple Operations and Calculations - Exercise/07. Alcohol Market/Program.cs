using System;
namespace _07.Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double WhiskeyPriceInLeva = double.Parse(Console.ReadLine());
            double beerInLitre = double.Parse(Console.ReadLine());
            double wineInLitre = double.Parse(Console.ReadLine());
            double rakiyaInLItre = double.Parse(Console.ReadLine());
            double whiskeyInLitre = double.Parse(Console.ReadLine());
            double rakiyaPriceInLeva = WhiskeyPriceInLeva / 2;
            double beerPriceInLeva = rakiyaPriceInLeva - rakiyaPriceInLeva * 0.8;
            double winePriceInLeva = rakiyaPriceInLeva - rakiyaPriceInLeva * 0.4;
            rakiyaPriceInLeva *= rakiyaInLItre;
            beerPriceInLeva *= beerInLitre;
            winePriceInLeva *= wineInLitre;
            Console.WriteLine($"{rakiyaPriceInLeva + beerPriceInLeva + winePriceInLeva + WhiskeyPriceInLeva * whiskeyInLitre:f2}");
        }
    }
}
