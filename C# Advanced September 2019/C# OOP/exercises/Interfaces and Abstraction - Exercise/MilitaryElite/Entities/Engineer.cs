namespace MilitaryElite.Entities
{
    using Contracts;
    using Enums;
    using System.Collections.Generic;
    using System.Text;

    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps,ICollection<IRepair> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = repairs;
        }

        public ICollection<IRepair> repairs { get; private set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Repairs:");
            foreach (var repair in this.repairs)
            {
                sb.AppendLine("  "+repair.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
