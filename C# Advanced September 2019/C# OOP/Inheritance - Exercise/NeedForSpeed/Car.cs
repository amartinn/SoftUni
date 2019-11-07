namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const int  defaultFuelConsuption = 3;

        public override double FuelConsumption => defaultFuelConsuption;
        public Car(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
        }

       
        

    }
}
