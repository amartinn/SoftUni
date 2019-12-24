

namespace MilitaryElite.Entities
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary,
            Dictionary<int,IPrivate> privates)
            : base(id, firstName, lastName, salary)
        {
            this.privates = privates;
        }

        public IDictionary<int, IPrivate> privates { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine("Privates:");
            foreach (var @private in this.privates.Values)
            {
                sb.AppendLine("  "+@private.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
