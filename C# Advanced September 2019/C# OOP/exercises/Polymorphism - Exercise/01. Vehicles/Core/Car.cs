namespace Vehicles.Core
{
    using Constants;
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double litresPerKm,int tankCapacity) 
            : base(fuelQuantity,litresPerKm,tankCapacity)
        {
            this.LitresPerKm += AirConditionerFuelIncrement;
        }

        public override double AirConditionerFuelIncrement => FuelIncrement.Car;
    }
}
