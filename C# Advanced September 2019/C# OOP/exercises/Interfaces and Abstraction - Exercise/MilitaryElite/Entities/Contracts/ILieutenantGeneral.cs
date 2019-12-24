
namespace MilitaryElite.Entities.Contracts
{
    using System.Collections.Generic;

    public interface ILieutenantGeneral
    {
        public IDictionary<int,IPrivate> privates { get; }
    }
}
