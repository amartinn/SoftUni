namespace WildFarm.Core.Animals.Bird
{
    using WildFarm.Constants;

    class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }
        public override double WeightIncrease => IncreaseWeight.Owl;
        public override string ProduceSound() => Sound.Owl;
    }
}
