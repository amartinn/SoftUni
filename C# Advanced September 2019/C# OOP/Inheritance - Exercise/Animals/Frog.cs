namespace Animals
{
    public class Frog : Animal
    {
        public Frog(string name, double age, Gender gender) 
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Ribbit";
        }
    }
}
