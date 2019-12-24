namespace P01_RawData.CarInfo
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;
        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = tires;
        }
        public string Model
        {
            get{return this.model;}
            private set{ this.model = value;}
        }
        public Engine Engine
        {
            get { return this.engine; }
            private set { this.engine = value; }
        }
        public Cargo Cargo
        {
            get { return this.cargo; }
            private set { this.cargo = value; }
        }

        public Tire[] Tires
        {
            get { return this.tires; }
            private set { this.tires = value; }
        }
     
    }

}
