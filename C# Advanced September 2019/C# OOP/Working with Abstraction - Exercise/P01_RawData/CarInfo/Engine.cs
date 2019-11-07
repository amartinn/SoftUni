namespace P01_RawData.CarInfo
{
    public class Engine
    {
        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }

        public int Speed { get; private set; }
        public int Power { get; private set; }
    }
}
