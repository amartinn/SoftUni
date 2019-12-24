
namespace P01_RawData.Factory
{
    using CarInfo;
    public interface ICarFactory
    {
        void Add(Car car);
        Car Create(string model, Engine engine, Cargo cargo, Tire[] tires);
    }
}
