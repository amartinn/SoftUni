using System;
namespace _01.Wedding_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskeyPriceInLeva = double.Parse(Console.ReadLine());
            double waterInLitre = double.Parse(Console.ReadLine());
            double wineInLitre = double.Parse(Console.ReadLine());
            double champangeInLitre = double.Parse(Console.ReadLine());
            double whiskeyInLitre = double.Parse(Console.ReadLine());

            double ChampagnePriceInLeva = whiskeyPriceInLeva * 0.5;
            double winePriceInLeva = ChampagnePriceInLeva * 0.4;
            double waterPriceInLeva = ChampagnePriceInLeva * 0.1;
            double champagneSum = ChampagnePriceInLeva * champangeInLitre;
            double wineSum = wineInLitre * winePriceInLeva;
            double waterSum = waterInLitre * waterPriceInLeva;
            double whiskeySum = whiskeyInLitre * whiskeyPriceInLeva;
            double total = wineSum + waterSum + whiskeySum + champagneSum;
            Console.WriteLine($"{total:f2}");
        }
    }
}
