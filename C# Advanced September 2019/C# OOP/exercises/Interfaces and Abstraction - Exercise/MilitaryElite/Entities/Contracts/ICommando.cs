
namespace MilitaryElite.Entities.Contracts
{
    using System.Collections.Generic;

   public interface ICommando
    {
        public ICollection<IMission> missions { get; }
    }
}
