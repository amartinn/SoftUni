namespace Vehicles.Core
{
    using Constants;
    using System;

    public class Truck : Vehicle
    {
        private const double truckTankHoleFuelLoose = 0.95;
        public Truck(double fuelQuantity, double litresPerKm, int tankCapacity)
            : base(fuelQuantity, litresPerKm, tankCapacity)
        {
            this.LitresPerKm += AirConditionerFuelIncrement;

        }

        public override double AirConditionerFuelIncrement => FuelIncrement.Truck;
        public override void Refuel(double litres)
        {

            var canFit = this.TankCapacity >= litres;
            if (litres <= 0)
            {
                throw new ArgumentException(ConstantMessages.FuelMustBePositive);
            }
            else if (canFit)
            {
                this.FuelQuantity += litres * truckTankHoleFuelLoose;
            }
            else
            {
                throw new ArgumentException(string.Format(ConstantMessages.VehicleTankCapacityIsLowerThanInitial, litres));
            }
        }

    }
}
