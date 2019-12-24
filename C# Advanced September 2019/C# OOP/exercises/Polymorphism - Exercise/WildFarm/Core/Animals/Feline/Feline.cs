

namespace WildFarm.Core.Animals.Feline
{
    using Contracts;
    using Mammal;
    public abstract class Feline : Mammal, IFeline
    {
        public Feline(string name, double weight, string LivingRegion,string Breed) 
            : base(name, weight, LivingRegion)
        {
            this.Breed = Breed;
        }

        public string Breed { get; }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
