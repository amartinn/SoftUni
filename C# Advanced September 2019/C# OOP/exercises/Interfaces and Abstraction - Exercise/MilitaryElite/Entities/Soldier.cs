

namespace MilitaryElite.Entities
{
    using Contracts;
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Id { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }
    }
}
