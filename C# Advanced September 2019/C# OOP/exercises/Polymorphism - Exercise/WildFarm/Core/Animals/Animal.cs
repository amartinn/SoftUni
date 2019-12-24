namespace WildFarm.Core.Animals
{
    using Contracts;
    using Constants;

    using System;
    public abstract class Animal : IAnimal
    {
        
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
          
        }

        public string Name { get; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; private set; }

       
        public abstract double WeightIncrease { get;}

        public void Feed(string foodType, int quantity)
        {
           
          
            var animaltype = this.GetType().Name.ToString();
            bool canEat = Validator.CanAnimalEatFoodType(animaltype, foodType);
            if (canEat)
            {
                this.Weight += this.WeightIncrease * quantity;
                this.FoodEaten += quantity;
            }
            else
            {
                throw new ArgumentException(string.Format(ConstantMessages.InvalidFoodType, this.GetType().Name, foodType));
            }
            
        }

        public abstract string ProduceSound();
    }
}
