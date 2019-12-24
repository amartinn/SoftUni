namespace MilitaryElite.Entities
{
    using System;
    using Contracts;
    class Spy :Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName,int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; }
        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}" + Environment.NewLine +
                $" Code Number: {this.CodeNumber}";
        }
    }
}
