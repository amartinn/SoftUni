using FoodShortage.Core.Contracts;

namespace FoodShortage.Core
{
    public abstract class Citizen : ICitizen, IBuyer
    {
        private const int initialFood = 0;

        protected Citizen(int age, string name)
        {
            Age = age;
            Name = name;
            this.Food = initialFood;
        }

        public int Age { get; private set; }

        public string Name { get; private set; }

        public int Food { get; protected set; }

        public abstract void BuyFood();
    }


}
