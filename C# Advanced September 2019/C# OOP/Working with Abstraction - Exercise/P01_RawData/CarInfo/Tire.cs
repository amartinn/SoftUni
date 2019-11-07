namespace P01_RawData.CarInfo
{
    public class Tire
    {
        public Tire(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }

        public int Age { get; private set; }
        public double Pressure { get; private set; }
    }
}

