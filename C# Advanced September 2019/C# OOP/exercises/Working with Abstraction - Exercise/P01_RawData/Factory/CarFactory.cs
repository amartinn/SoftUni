
namespace P01_RawData.Factory
{
    using System.Collections.Generic;
    using CarInfo;
    public class CarFactory : ICarFactory
    {
        private readonly List<Car> cars;

        public CarFactory()
        {
            this.cars = new List<Car>();
        }

        public List<Car> GetCars()
        {
            return this.cars;
        }
        public void Add(Car car)
        {
            this.cars.Add(car);
        }

        public Car Create(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            return new Car(model, engine, cargo, tires);
        }

      
    }
}
