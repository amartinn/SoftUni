namespace WildFarm
{
    using System;
    using System.Collections.Generic;

    using Core.Contracts;
    using Factory;
    using IO;
    class Engine : IEngine
    {
        public void Run(ConsoleWriter writer, 
            ConsoleReader reader,
            AnimalFactory factory)
        {
            List<IAnimal> animals = new List<IAnimal>();
            
            var countLines = 1;
            var animalCount = 0;
            var command = string.Empty;
            while ((command=reader.ReadLine())!="End")
            {
                IAnimal animal = null;
                IFood food;
                if (countLines%2!=0)
                {
                    var animalInfo = command.Split();
                    animal = factory.Create(animalInfo);
                    animals.Add(animal);
                    
                }
                else
                {
                    var foodInfo = command.Split();
                    var foodType = foodInfo[0];
                    var foodQuantity = int.Parse(foodInfo[1]);
                    var foodTypewithReflection = Type.GetType($"WildFarm.Core.Food.{foodType}");
                    food = Activator.CreateInstance(foodTypewithReflection, foodQuantity) as IFood;
                    try
                    {
                        writer.WriteLine(animals[animalCount].ProduceSound());
                       animals[animalCount].Feed(foodType, foodQuantity);
                    }
                    catch (Exception ex )
                    {

                        writer.WriteLine(ex.Message);
                    }
                    animalCount++;
                }
             
                countLines++;
            }
            animals.ForEach(a => writer.WriteLine(a));
        }
    }
}
