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
                var carInfo = Console.ReadLine().Split();
                var carModel = carInfo[0];
                var engineSpeed = int.Parse(carInfo[1]);
                var enginePower = int.Parse(carInfo[2]);
                var cargoWeight = int.Parse(carInfo[3]);
                var cargoType = carInfo[4];
                var tires = new List<Tire>();
                for (int j = 5; j < carInfo.Length; j+=2)
                {
                    var currentTirePressure = double.Parse(carInfo[j]);
                    var currentTireAge = int.Parse(carInfo[j + 1]);
                    var tire = new Tire(currentTirePressure, currentTireAge);
                    tires.Add(tire);
                }
                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var car = new Car(engine, cargo, tires,carModel);
                cars.Add(car);
            }
                var keyWord = Console.ReadLine();

            if (keyWord=="fragile")
            {
                cars = cars
                    .Where(c => c.Cargo.CargoType == "fragile" && c.Tires.Any(t => t.TirePressure < 1))
                    .ToList();
            }
            else
            {
                cars = cars
                    .Where(c => c.Cargo.CargoType == "flamable" && c.Engine.EnginePower >= 250)
                    .ToList();
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
