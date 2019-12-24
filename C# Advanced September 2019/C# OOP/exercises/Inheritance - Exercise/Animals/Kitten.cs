namespace Animals
{
    public class Kitten : Cat
    {
        private const Gender gender = Gender.Female;
        public Kitten(string name, double age) 
            : base(name, age, gender)
        {
        }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
