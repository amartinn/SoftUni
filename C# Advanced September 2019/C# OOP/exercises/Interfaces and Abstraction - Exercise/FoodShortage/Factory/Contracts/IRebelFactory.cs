namespace FoodShortage.Factory.Contracts
{
    using Core;
    public interface IRebelFactory
    {
        Rebel Create(string name, int age, string group);
    }
}
