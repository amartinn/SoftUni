using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    class Parking
    {
        private List<Car> cars;
        private int capacity;
        private int count;
        public Parking(int capacity)
        {
            this.cars = new List<Car>();
            this.capacity = capacity;
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        

        public int Count
        {
            get { return this.cars.Count; ; }
            private set { count = this.cars.Count; }
        }

        public string AddCar(Car car)
        {
            var returnInfo = string.Empty;
            if (this.cars.Any(x=>x.RegistrationNumber==car.RegistrationNumber))
            {
                returnInfo = "Car with that registration number, already exists!";
            }
            else if (this.cars.Count>=this.capacity)
            {
                returnInfo = "Parking is full!";
            }
            else
            {
                cars.Add(car);
                returnInfo = $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
            return returnInfo;
        }
        public string RemoveCar(string registrationNumber)
        {
            var returnInfo = string.Empty;
            if (this.cars.All(x => x.RegistrationNumber != registrationNumber))
            {
                returnInfo = "Car with that registration number, doesn't exist!";
            }
            else
            {
                returnInfo = $"Successfully removed {registrationNumber}";
                var carToRemove = this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
                this.cars.Remove(carToRemove);
            }
            return returnInfo;
        }
        public Car GetCar(string registrationNumber)
        {
            var car = this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
            if (car==null)
            {
                return null;
            }
            else
            {
                return car;
            }  
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                var carToRemove = this.cars.FirstOrDefault(x => x.RegistrationNumber == number);
                if (carToRemove!=null)
                {
                    this.cars.Remove(carToRemove);
                }
            }
        }

    }
}
