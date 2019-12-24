namespace FoodShortage.Factory
{
    using Core;
    using Contracts;
    public class RebelFactory : IRebelFactory
    {
        public Rebel Create(string name, int age, string group)
        {
            var rebel = new Rebel(age, name, group);
            return rebel;
        }
    }
}
