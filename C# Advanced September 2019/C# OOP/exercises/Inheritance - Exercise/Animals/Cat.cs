namespace Animals
{
    public class Cat : Animal  
    {
        public Cat(string name, double age, Gender gender) 
            : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow meow";
        }
    }
}
