

namespace BorderControl.Core
{
    using Core.Contracts;
    public class Pet : Citizen, IPet
    {
        public Pet(string name, string birthdate ) 
            : base(name)
        {
            this.Birthdate = birthdate;
        }

        public string Birthdate { get; private set; }

        public override string Id => throw new System.NotImplementedException();
    }
}
