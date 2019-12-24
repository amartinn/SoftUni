namespace BorderControl.Core
{
    using Contracts;
    public class Person : Citizen, IPerson
    {
        public Person(string name, string id, int age) 
            : base(name,id)
        {
            this.Age = age;
        }

        public int Age { get; private set; }
    }
}
