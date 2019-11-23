namespace Vehicles.Core
{
    using Constants;
    using System;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double litresPerKm,int tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.LitresPerKm = litresPerKm;
            
        }
        public double FuelQuantity {
            get
            {
                return this.fuelQuantity;
            } 
            protected set
            {
                if (value>this.TankCapacity)
                {
                    value = 0;

                }
                this.fuelQuantity = value;  
            }
        }
        public int TankCapacity { get; }
        public double LitresPerKm { get; protected set; }

        public abstract double AirConditionerFuelIncrement { get; }

    

        public virtual string Drive(double distance)
        {
            string message = string.Empty;
            bool canDrive = this.FuelQuantity >= this.LitresPerKm * distance;
            if (canDrive)
            {
                this.FuelQuantity -= LitresPerKm * distance;
                message = string.Format(ConstantMessages.VehicleTravel, this.GetType().Name, distance);
            }
            else
            {
                message = string.Format(ConstantMessages.VehicleRefuel, this.GetType().Name);
            }
            return message;
        }
        public virtual void Refuel(double litres)
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

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
