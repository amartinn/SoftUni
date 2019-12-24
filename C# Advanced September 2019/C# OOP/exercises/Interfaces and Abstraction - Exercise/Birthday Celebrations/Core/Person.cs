namespace BorderControl.Core
{
    using Contracts;
    public class Person : Citizen, IPerson
    {
        public Person(string name, string id, int age,string birthdate) 
            : base(name)
        {
            this.Id = id;
            this.Age = age;
            this.birthDate = birthDate;
        }

        public int Age { get; private set; }

        public string birthDate { get; private set; }
        public override string Id => base.Id;

    }
}
