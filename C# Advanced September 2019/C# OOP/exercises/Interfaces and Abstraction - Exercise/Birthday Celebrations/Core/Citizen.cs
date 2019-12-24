namespace BorderControl.Core
{
    using Contracts;
    public abstract class Citizen : ICitizen
    {
        protected Citizen(string name)
        {
            this.Name = name;
        }
        public virtual string Id { get; protected set; }

        public string Name { get; private set; }

    }
}
