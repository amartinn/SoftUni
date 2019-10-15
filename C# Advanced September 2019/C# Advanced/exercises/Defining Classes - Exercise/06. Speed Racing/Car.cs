namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;
        private double totalKilometers;
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.travelledDistance = 0;
            this.totalKilometers = this.fuelAmount / this.fuelConsumptionPerKilometer;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }
        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }
        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }
        public bool canMove(double kilometersToDrive)
        {
            var totalFuelToConsume = kilometersToDrive * this.fuelConsumptionPerKilometer;
            if (totalFuelToConsume<=this.FuelAmount)
            {
                this.FuelAmount -= totalFuelToConsume;
                this.travelledDistance += kilometersToDrive;
                return true;
            }
            return false;
        }
    }
}
