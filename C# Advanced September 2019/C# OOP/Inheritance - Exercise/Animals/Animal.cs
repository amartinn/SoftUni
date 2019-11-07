namespace Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double age,Gender gender)
        {
            Name = name;
            Age = age;
            this.Gender = gender;
        }

        protected string Name { get; private set; }
        protected double Age { get; private set; }
        protected Gender Gender { get; private set; }


        public abstract string ProduceSound();
        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}
