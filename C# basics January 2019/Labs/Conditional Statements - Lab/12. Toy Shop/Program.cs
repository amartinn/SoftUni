using System;
namespace _12.Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double trip = double.Parse(Console.ReadLine());
            double puzzle = double.Parse(Console.ReadLine());
            double dolls = double.Parse(Console.ReadLine());
            double teddybears = double.Parse(Console.ReadLine());
            double minions = double.Parse(Console.ReadLine());
            double trucks = double.Parse(Console.ReadLine());


            double money = puzzle * 2.60 + dolls * 3 + teddybears * 4.10 + minions * 8.20 + trucks * 2;
            double toys = puzzle + dolls + teddybears + minions + trucks;
            double discount = 0;
            if (toys >= 50)
            {
                discount = money / 4;
            }
            double price = money - discount;
            double rent = price * 0.1;
            double income = price - rent;
            double left = 0;
            if (income >= trip)
            {
                left = income - trip;
            }
            if (trip <= income)
            {
                Console.WriteLine("Yes! {0:F2} lv left.", income - trip);
            }
            else
            {
                Console.WriteLine("Not enough money! {0:F2} lv needed.", Math.Abs(income - trip));
            }
        }
    }
}
