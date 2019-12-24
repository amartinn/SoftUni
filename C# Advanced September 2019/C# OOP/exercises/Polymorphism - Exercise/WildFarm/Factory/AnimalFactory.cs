namespace WildFarm.Factory
{
    using System;
    using Core.Animals.Bird;
    using Core.Animals.Mammal;
    using Core.Animals.Feline;
    using Core.Contracts;
    public class AnimalFactory
    {
        public IAnimal Create(string[] animalArgs)
        {
            var animal = ValidateAnimal(animalArgs);
            if (animal!=null)
            {
                return animal;
            }
            return null;
        }
        private IAnimal ValidateAnimal(string []args)
        {
            var type = args[0];
            var animalName = args[1];
            var animalWeight = double.Parse(args[2]);
            IAnimal animal = null;
            if (Validator.isBird(type))
            {
                var wingSize = double.Parse(args[3]);
                animal = Activator.CreateInstance(typeof(Hen), animalName, animalWeight, wingSize) as IAnimal;
                if (type=="Owl")
                {
                    animal = Activator.CreateInstance(typeof(Owl), animalName, animalWeight, wingSize) as IAnimal;
                }
        
            
            }
            else if (Validator.IsMammal(type))
            {
                var livingRegion = args[3];
                animal = Activator.CreateInstance(typeof(Dog), animalName, animalWeight, livingRegion) as IAnimal;
                if (type == "Mouse")
                {
                    animal = Activator.CreateInstance(typeof(Mouse), animalName, animalWeight, livingRegion) as IAnimal;
                }

            }
            else if (Validator.IsFeline(type))
            {
                var livingRegion = args[3];
                var breed = args[4];
                animal = Activator.CreateInstance(typeof(Tiger), animalName, animalWeight, livingRegion,breed) as IAnimal;
                if (type == "Cat")
                {
                    animal = Activator.CreateInstance(typeof(Cat), animalName, animalWeight, livingRegion, breed) as IAnimal;
                }

              
            }
            return animal;
        }

    }
}
