using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            var engines = new List<Engine>();
            var cars = new List<Car>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var engineInfo = Console.ReadLine().Split();
                var engineModel = engineInfo[0];
                var enginePower = int.Parse(engineInfo[1]);
                var engine = new Engine(engineModel, enginePower);
                if (engineInfo.Length == 3)
                {
                    int displacement;
                    if (int.TryParse(engineInfo[2], out displacement))
                    {
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        engine.Efficiency = engineInfo[2];
                    }
                }
                else if (engineInfo.Length == 4)
                {
                    int displacement = int.Parse(engineInfo[2]);
                    string efficiency = engineInfo[3];
                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }

               
                engines.Add(engine);

            }
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine().Split(new char[] { ' '},StringSplitOptions.RemoveEmptyEntries);
                var carModel = carInfo[0];
                var carEngineModel = carInfo[1];
                var carEngine = engines.FirstOrDefault(x => x.Model == carEngineModel);
                var car = new Car(carModel, carEngine);

                if (carInfo.Length == 3)
                {
                    int weight;
                    if (int.TryParse(carInfo[2], out weight))
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = carInfo[2];
                    }
                }
                else if (carInfo.Length == 4)
                {
                    var weight = int.Parse(carInfo[2]);
                    var color = carInfo[3];
                    car.Weight = weight;
                    car.Color = color;
                }
                cars.Add(car);
            }
            foreach (var car in cars)
            {
                var missing = "n/a";
                Console.WriteLine(car.Model + ":");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                if (car.Engine.Displacement==null)
                {
                    Console.WriteLine($"    Displacement: {missing}");
                }
                else
                {
                    Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                }
                if (car.Engine.Efficiency == null)
                {
                    Console.WriteLine($"    Efficiency: {missing}");
                }
                else
                {
                    Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                }
                if (car.Weight==null)
                {
                    Console.WriteLine($"  Weight: {missing}");
                }
                else
                {
                    Console.WriteLine($"  Weight: {car.Weight}");
                }
                if (car.Color==null)
                {
                    Console.WriteLine($"  Color: {missing}");
                }
                else
                {
                    Console.WriteLine($"  Color: {car.Color}");
                }
            }
        }
    }
}
