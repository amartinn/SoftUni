namespace FoodShortage.Core
{
    using FoodShortage.Core.Contracts;

    public class Person : Citizen, IPerson
    {
        public Person(int age, string name,string id,string birthdate)
            : base(age, name)
        {
            this.Birthdate = birthdate;
            this.Id = id;
        }

        public string Birthdate { get; private set; }


        public string Id { get; private set; }

        public override void BuyFood()
        {
            this.Food += 10;
        }
    }
}
