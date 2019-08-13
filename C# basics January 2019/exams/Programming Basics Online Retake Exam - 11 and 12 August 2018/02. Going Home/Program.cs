using System;
namespace _02.Going_Home
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal destinationKm = decimal.Parse(Console.ReadLine());
            decimal petrolfor100Km = decimal.Parse(Console.ReadLine());
            decimal petrolPrice = decimal.Parse(Console.ReadLine());
            decimal money = decimal.Parse(Console.ReadLine());
            decimal carCost = (destinationKm * petrolfor100Km)/100;
            carCost *= petrolPrice;
            if (money>=carCost)
            {
                Console.WriteLine($"You can go home. {Math.Abs(carCost-money):f2} money left.");
            }
            else
            {
                decimal each = money / 5;
                Console.WriteLine($"Sorry, you cannot go home. Each will receive {each:f2} money.");
            }
        }
    }
}
