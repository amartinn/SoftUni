namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters) 
            : base(name, price)
        {
            this.Mililitres = milliliters;
        }
        public double Mililitres { get; set; }
    }
}
