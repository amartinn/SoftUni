namespace NeedForSpeed
{
    class SportCar : Car
    {
        private const double defaultFuelConsuption = 10;
        public override double FuelConsumption => defaultFuelConsuption;

        public SportCar(int horsePower,double fuel)
            :base(horsePower,fuel)
        {

        }
    }
}
