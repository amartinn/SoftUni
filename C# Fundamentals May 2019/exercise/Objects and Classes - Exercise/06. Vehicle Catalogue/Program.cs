using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = string.Empty;
            var carHp = 0.0;
            var truckHp = 0.0;
            var truckCount = 0;
            var carCount = 0;
            var catalogue = new List<Vehicle>();
            while ((command=Console.ReadLine())!="End")
            {
                var input = command.Split(" ");
                var type = input[0];
                var model = input[1];
                var color = input[2];
                var hp = int.Parse(input[3]);
                if (input[0]=="car")
                {
                    type = "Car";
                }
                else
                {
                    type = "Truck";
                }
               
                Vehicle vehicle = new Vehicle(type, model, color, hp);
                catalogue.Add(vehicle);
            }
            while ((command=Console.ReadLine())!= "Close the Catalogue")
            {
                Vehicle toPrint = catalogue.FirstOrDefault(x => x.Model == command);
                Console.WriteLine(toPrint);
            }
            var cars = catalogue.Where(x => x.Type == "Car").ToList();
            var trucks = catalogue.Where(x => x.Type == "Truck").ToList();
            var carsAvg = cars.Count > 0 ? cars.Average(x => x.HorsePower) : 0.0;
            var trucksAvg = trucks.Count > 0 ? trucks.Average(x => x.HorsePower) : 0.0;
            Console.WriteLine($"Cars have average horsepower of: {carsAvg:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAvg:f2}.");
        }
    }
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
        public Vehicle(string type,string model,string color,int hp)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = hp;
        }
        public override string ToString()
        {
            return  $"Type: {this.Type}"+ Environment.NewLine +
                $"Model: {this.Model}" + Environment.NewLine+
                $"Color: {this.Color}" +Environment.NewLine+
                $"Horsepower: {this.HorsePower}";
        }
    }
}
