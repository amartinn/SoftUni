using System;

namespace WildFarm
{
    using System.Linq;
    using System.Reflection;
    public static class Validator
    {
        public static bool CanAnimalEatFoodType(string animalType, string foodType)
        {
            var type = Type.GetType("WildFarm.Constants.AnimalFood").GetFields(
                BindingFlags.Static | BindingFlags.Public
                | BindingFlags.Instance | BindingFlags.NonPublic);

            var foodEaten = type.FirstOrDefault(a => a.IsLiteral 
            & !a.IsInitOnly 
            & a.Name == animalType);

            var value = (string)foodEaten.GetRawConstantValue();
            var result = value.Contains(foodType);
            return result;
        }
        public static bool IsFeline(string animalType)=>GetParrent("Feline", animalType);

        public static bool IsMammal(string animalType) => GetParrent("Mammal", animalType);

        public static bool isBird(string animalType) => GetParrent("Bird", animalType);
        private static bool GetParrent(string parent,string animalType)
        {
            var result = Assembly.GetExecutingAssembly()
                 .GetTypes()
                 .FirstOrDefault(x => x.Name == animalType)
                 .BaseType.Name == parent;
            return result;
        }
    }
}
