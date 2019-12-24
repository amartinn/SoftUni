namespace WildFarm.Core.Animals.Mammal
{
    using Constants;
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string LivingRegion) 
            : base(name, weight, LivingRegion)
        {
        }


        public override double WeightIncrease => IncreaseWeight.Dog;


        public override string ProduceSound() => Sound.Dog;
    }
}
