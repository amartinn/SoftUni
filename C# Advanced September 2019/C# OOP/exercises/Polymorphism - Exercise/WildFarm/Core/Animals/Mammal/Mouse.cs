namespace WildFarm.Core.Animals.Mammal
{
    using Constants;
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string LivingRegion) 
            : base(name, weight, LivingRegion)
        {
        }

        public override double WeightIncrease => IncreaseWeight.Mouse;

        public override string ProduceSound() => Sound.Mouse;
    }
}
