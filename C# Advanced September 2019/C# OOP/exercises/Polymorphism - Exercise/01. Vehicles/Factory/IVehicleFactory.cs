namespace Vehicles.Factory
{
    using Vehicles.Core;
    public interface IVehicleFactory
    {
        Vehicle Create(string type,double fuel, double distance,int capacity);
    }
}
