
namespace MilitaryElite.Entities.Contracts
{
    using MilitaryElite.Enums;
    public interface ISpecialisedSoldier:ISoldier
    {
        
        public Corps Corps { get; }
    }
}
