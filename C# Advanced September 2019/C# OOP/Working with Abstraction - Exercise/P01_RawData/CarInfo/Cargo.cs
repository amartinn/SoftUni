namespace P01_RawData.CarInfo
{
    public class Cargo
    {
        public string Type { get; private set; }
        public int Weight { get; private set; }
        public Cargo(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }
    }
}
