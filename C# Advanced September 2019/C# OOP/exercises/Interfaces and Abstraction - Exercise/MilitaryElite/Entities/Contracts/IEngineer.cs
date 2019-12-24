
namespace MilitaryElite.Entities.Contracts
{
    using System.Collections.Generic;

    interface IEngineer
    {
        public ICollection<IRepair> repairs { get; }
    }
}
