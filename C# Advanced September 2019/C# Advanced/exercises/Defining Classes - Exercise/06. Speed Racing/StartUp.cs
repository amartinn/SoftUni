using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                var carArgs = Console.ReadLine().Split();
                var carModel = carArgs[0];
                var fuelAmount = double.Parse(carArgs[1]);
                var fuelConsumptionFor1km = double.Parse(carArgs[2]);
                var car = new Car(carModel, fuelAmount, fuelConsumptionFor1km);
                cars.Add(car);
            }
            var line = string.Empty;
            while ((line=Console.ReadLine())!="End")
            {
                var currentCarInfo = line.Split();
                var currentCarModel = currentCarInfo[1];
                var aboutOfKmToDrive = double.Parse(currentCarInfo[2]);
                var car = cars.FirstOrDefault(x => x.Model == currentCarModel);
                if (car!=null)
                {
                    if (car.canMove(aboutOfKmToDrive))
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }
                }

            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }

        }
    }
}
