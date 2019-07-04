using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new Dictionary<string, string>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split();
                var command = line[0];
                var userName = line[1];
                
                if (command=="register")
                {
                    var licensePlateNumber = line[2];
                    if (!cars.ContainsKey(userName))
                    {
                        cars[userName] = licensePlateNumber;
                        Console.WriteLine($"{userName} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                    
                }
                else
                {
                    if (cars.ContainsKey(userName))
                    {
                        cars.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                }
                
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} => {car.Value}");
            }

        }
    }
}
