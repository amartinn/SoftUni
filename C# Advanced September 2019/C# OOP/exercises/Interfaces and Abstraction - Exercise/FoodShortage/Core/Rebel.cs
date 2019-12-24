namespace FoodShortage.Core
{
    using FoodShortage.Core.Contracts;
    public class Rebel : Citizen, IRebel
    {
        public Rebel(int age, string name,string group)
            : base(age, name)
        {
            this.Group = group;
        }

        public string Group { get; private set; }

        public override void BuyFood()
        {
            this.Food += 5;
        }
    }
}
