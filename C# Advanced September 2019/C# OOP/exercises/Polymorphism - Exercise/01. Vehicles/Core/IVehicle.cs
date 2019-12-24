namespace Vehicles.Core
{
     public interface IVehicle
    {
        double FuelQuantity { get; }
        double LitresPerKm { get; }
        int TankCapacity { get; }
        abstract void Refuel(double litres);
        public abstract double AirConditionerFuelIncrement { get; }
    }
}
