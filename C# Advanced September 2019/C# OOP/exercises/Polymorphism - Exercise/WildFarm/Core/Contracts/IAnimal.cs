namespace WildFarm.Core.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
        abstract double  WeightIncrease {get;}
        abstract string ProduceSound();
        abstract void Feed(string foodType, int quantity);
    }
}
