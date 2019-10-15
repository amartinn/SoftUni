using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class Family
    {
        private List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }
        public void AddMember(Person member) => this.people.Add(member);
        public Person GetOldestMember() => this.people.OrderByDescending(x => x.Age).First();
        

    }
}
