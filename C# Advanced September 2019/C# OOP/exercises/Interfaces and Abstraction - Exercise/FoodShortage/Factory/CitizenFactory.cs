namespace FoodShortage.Factory
{
    using Core;
    using Contracts;
    public class CitizenFactory : ICitizenFactory
    {
        public Person Create(string name, int age, string id, string birthdate)
        {
            var citizen = new Person(age, birthdate, name, id);
            return citizen;
        }
    }
}
