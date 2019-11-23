namespace Ferarri
{
    public abstract class Car : ICar
    {
        public abstract string Model { get;  }
        public string Driver { get; private set; }

        protected Car(string driver)
        {
            this.Driver = driver;
        }
    }
}
