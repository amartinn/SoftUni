namespace WildFarm.Core.Animals.Mammal
{
    using Contracts;

    public abstract class Mammal : Animal,IMammal
    {
        public Mammal(string name, double weight,string LivingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = LivingRegion;
        }

        public string LivingRegion { get; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
