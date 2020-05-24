using System;

namespace _01._Spring_Vacation_Trip
{
    class Program
        {
            static void Main(string[] args)
            {
            var days = int.Parse(Console.ReadLine());
            var budget = double.Parse(Console.ReadLine());
            var groupOfPeople = int.Parse(Console.ReadLine());
            var fuelPerKM = double.Parse(Console.ReadLine());
            var foodExpensesPerPerson = double.Parse(Console.ReadLine());
            var hotelRoomPricePerPerson = double.Parse(Console.ReadLine());

            if (groupOfPeople > 10)
            {
                hotelRoomPricePerPerson *= 0.75;
            }
            var currentExpenses = days * groupOfPeople * (foodExpensesPerPerson + hotelRoomPricePerPerson);

            for (int i = 1; i <= days; i++)
            {
                var travelledDistance = double.Parse(Console.ReadLine());
                currentExpenses += travelledDistance * fuelPerKM;

                if (i % 3 == 0 || i % 5 == 0)
                {
                    currentExpenses *= 1.4;
                }
                if (i % 7 == 0)
                {
                    currentExpenses -= currentExpenses / groupOfPeople;
                }

                if (currentExpenses > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {(currentExpenses - budget):f2}$ more.");
                    return;
                }
            }
            Console.WriteLine($"You have reached the destination. You have {(budget - currentExpenses):f2}$ budget left.");

        }
        }
    }
