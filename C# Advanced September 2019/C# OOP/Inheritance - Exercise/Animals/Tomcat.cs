
namespace Animals
{
   public class Tomcat : Cat
    {
        private const Gender gender = Gender.Male;
        public Tomcat(string name, double age)
            : base(name, age, gender)
        {
        }
        public override string ProduceSound()
        {
            return  "MEOW";
        }
    }
}
