using System;

namespace Animals
{
    class Engine
    {
        public void Run()
        {
            var command = string.Empty;
            while ((command = Console.ReadLine()) != "Beast!")
            {
                var animalType = command;
                var parts = Console.ReadLine().Split();
                var animalName = parts[0];
                var animalAge = double.Parse(parts[1]);
                var animalGender = parts[2];
                var animal = GetAnimal(animalType, animalName, animalAge,animalGender);
                if (animal != null)
                {
                    Console.WriteLine(animal);
                    Console.WriteLine(animal.ProduceSound());
                }
            }
        }
        public Animal GetAnimal(string animalType, string animalName, double animalAge,string animalGender)
        {
            Animal animal;
            if (animalType.Length <= 0 || animalName.Length <= 0 || animalAge <= 0)
            {
                Console.WriteLine("Invalid input!");
                return null;
            }
            if (animalType == "Dog")
            {
                animal = new Dog(animalName, animalAge, (Gender)Enum.Parse(typeof(Gender), animalGender));

            }
            else if (animalType == "Cat")
            {
                animal = new Cat(animalName, animalAge, (Gender)Enum.Parse(typeof(Gender), animalGender));

            }
            else if (animalType == "Frog")
            {
                animal = new Frog(animalName, animalAge, (Gender)Enum.Parse(typeof(Gender), animalGender));

            }
            else if (animalType == "Kitten")
            {
                animal = new Kitten(animalName, animalAge);

            }
            else if (animalType == "Tomcat")
            {
                animal = new Tomcat(animalName, animalAge);

            }
            else
            {
                Console.WriteLine("Invalid input!");
                return null;
            }
            return animal;
        }
    }
}