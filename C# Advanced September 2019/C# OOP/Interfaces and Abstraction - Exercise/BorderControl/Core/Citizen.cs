namespace BorderControl.Core
{
    using Contracts;
    public abstract class Citizen : ICitizen
    {
        protected Citizen(string name,string id )
        {
            this.Id = id;
            this.Name = name;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }
    }
}
