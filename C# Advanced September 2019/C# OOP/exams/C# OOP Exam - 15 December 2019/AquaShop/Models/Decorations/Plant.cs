namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
         private const int initialComfort = 5;
        private const decimal initialPrice = 10;
        public Plant() 
            : base(initialComfort, initialPrice)
        {
        }
    }
}