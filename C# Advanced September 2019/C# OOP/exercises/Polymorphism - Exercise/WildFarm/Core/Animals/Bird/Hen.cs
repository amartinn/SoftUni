namespace WildFarm.Core.Animals.Bird
{
    using Constants;

    class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override double WeightIncrease => IncreaseWeight.Hen;

        public override string ProduceSound() => Sound.Hen;
    }
}
