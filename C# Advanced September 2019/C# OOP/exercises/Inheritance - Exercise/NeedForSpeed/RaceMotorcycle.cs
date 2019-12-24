namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {

        private const double defaultFuelConsuption = 8;
        public override double FuelConsumption => defaultFuelConsuption;
        public RaceMotorcycle(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
        }

       



    }
}
