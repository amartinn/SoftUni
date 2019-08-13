using System;
namespace _01.Sea_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyForFoodEachDay = double.Parse(Console.ReadLine());
            double moneyForSouvenirsEachDay = double.Parse(Console.ReadLine());
            double moneyForHotel = double.Parse(Console.ReadLine());
            double km = 420;
            double petrol = (km / 100)*7;
            petrol *= 1.85;
            double rest = 3 * moneyForFoodEachDay + 3 * moneyForSouvenirsEachDay;
            double firstDayDiscount = moneyForHotel * 0.9;
            double secondDayDiscount = moneyForHotel * 0.85;
            double thirdDayDiscount = moneyForHotel * 0.8;
            double total = petrol + firstDayDiscount + secondDayDiscount + thirdDayDiscount + rest;
            Console.WriteLine($"Money needed: {total:f2}");
            
        }
    }
}
