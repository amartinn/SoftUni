namespace BorderControl.Core
{
    using Contracts;
    class Robot : Citizen
    {
        public Robot(string name, string id) 
            : base(name)
        {
            this.Id = id;   
        }
        public override string Id { get => base.Id; protected set => base.Id = value; }
    }
}
