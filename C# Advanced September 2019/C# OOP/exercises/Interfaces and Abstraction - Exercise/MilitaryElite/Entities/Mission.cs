namespace MilitaryElite.Entities
{
    using Contracts;
    using MilitaryElite.Enums;

   public class Mission : IMission
    {
        public Mission(string codeName, State state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; }

        public State State { get; private set; }

        public void ComplateMission()
        {
            this.State = State.Finished;
        }
        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
