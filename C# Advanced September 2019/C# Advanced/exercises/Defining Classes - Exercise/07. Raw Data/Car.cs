using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private Engine engine;
        private Cargo cargo;
        private List<Tire> tires;
        private string model;
        public Car(Engine engine, Cargo cargo, List<Tire> tires,string model)
        {
            this.engine = engine;
            this.cargo = cargo;
            this.tires = new List<Tire>();
            this.tires = tires;
            this.model = model;

        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }
        public List<Tire> Tires
        {
            get { return tires; }
            set { tires = value; }
        }


    }
}
