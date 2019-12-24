namespace WildFarm.Core.Animals.Feline
{
    using Constants;
    public class Cat : Feline
    {
        public Cat(string name, double weight, string LivingRegion, string Breed) 
            : base(name, weight, LivingRegion, Breed)
        {
        }

        public override double WeightIncrease => IncreaseWeight.Cat;

        public override string ProduceSound() => Sound.Cat;

    }
}
