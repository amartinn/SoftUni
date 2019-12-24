namespace WildFarm.Core.Animals.Feline
{
    using Constants;
    class Tiger : Feline

    {
        public Tiger(string name, double weight, string LivingRegion, string Breed) 
            : base(name, weight, LivingRegion, Breed)
        {
        }

        public override double WeightIncrease => IncreaseWeight.Tiger;

        public override string ProduceSound() => Sound.Tiger;
    }
}
