

namespace MilitaryElite.Entities
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Enums;
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps,ICollection<IMission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = missions;
        }

        public ICollection<IMission> missions { get; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");
            foreach (var mission in missions)
            {
                sb.AppendLine("  "+mission.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
