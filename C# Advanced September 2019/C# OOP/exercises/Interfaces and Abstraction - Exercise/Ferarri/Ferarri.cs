namespace Ferarri
{
   public class Ferarri : Car, IFerrari
    {
        public Ferarri(string driver) 
            : base(driver)
        {
        }

        public override string Model => ConstantMessages.FerrariModel;

        public string PushGasPedal() => ConstantMessages.Gas;

        public string UseBrakes() => ConstantMessages.Brake;
        public override string ToString()
        {
            return $"{this.Model}/{this.UseBrakes()}/{this.PushGasPedal()}/{this.Driver}";
        }
    }
}
