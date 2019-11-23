namespace Vehicles.Core
{
    using Constants;
    using System;

    public class Bus : Vehicle
    {
       
        public Bus(double fuelQuantity, double litresPerKm, int tankCapacity) 
            : base(fuelQuantity, litresPerKm, tankCapacity)
        {
        }
        public override double AirConditionerFuelIncrement => FuelIncrement.Bus;
        public  bool HasPeople = true;
        public override void Refuel(double litres)
        {
            var canFit = this.TankCapacity >= litres;
             if (litres <= 0)
            {
                throw new ArgumentException(ConstantMessages.FuelMustBePositive);
            }
            else if (canFit)
            {
                this.FuelQuantity += litres;    
            }
            
            else 
            {
                throw new ArgumentException(string.Format(ConstantMessages.VehicleTankCapacityIsLowerThanInitial, litres));
            }
        }
        public override string Drive(double distance)
        {
            var message = string.Empty;
            LitresPerKm = HasPeople ? LitresPerKm + AirConditionerFuelIncrement : LitresPerKm;
            var canDrive = this.FuelQuantity >= this.LitresPerKm * distance;

            if (canDrive)
            {
                this.FuelQuantity -= LitresPerKm * distance;
                message = string.Format(ConstantMessages.VehicleTravel, this.GetType().Name, distance);
            }
            else
            {
                message = string.Format(ConstantMessages.VehicleRefuel, this.GetType().Name);
            }
            this.HasPeople = false;
            return message;
        }
    }
}
