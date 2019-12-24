namespace MilitaryElite.Entities.Contracts
{
    using Enums;
    public interface IMission
    {
        public string CodeName {get;}
        public State State { get; }
        public void ComplateMission();
    }
}
