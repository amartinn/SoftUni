namespace FoodShortage.Core.Contracts
{
    public interface IBuyer
    {
        public int Food { get; }
       abstract void BuyFood();
    }
}
