
using System.Runtime.InteropServices;
namespace DefiningClasses
{
    public class Engine
    {

        private string model;
        private int power;
        private int? displacement;
        private string efficiency;

        public Engine(string model, int power, int? displacement = null ,string efficiency =null)
        {
            this.model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }  
        public int? Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }
        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }


    }
}
