namespace NeedForSpeed
{
    public class Vehicle
    {
       
        private const double DefaultFuelConsumption =1.25;
        public virtual double FuelConsumption  => DefaultFuelConsumption;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public Vehicle(int horsePower,double fuel)
        {
           this.Fuel = fuel;
           this.HorsePower = horsePower;
        }
        public void Drive(double kilometers)
        {
            bool canDrive = this.Fuel - kilometers * this.FuelConsumption >= 0;
            if (canDrive)
            {
                this.Fuel -= kilometers * this.FuelConsumption;
            }
         
        }

    }
}
