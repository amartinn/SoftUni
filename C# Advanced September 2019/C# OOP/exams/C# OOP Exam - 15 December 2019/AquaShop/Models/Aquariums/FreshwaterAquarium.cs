namespace AquaShop.Models.Aquariums
{
    class FreshwaterAquarium : Aquarium
    {
        private const int capacity = 50;
        public FreshwaterAquarium(string name)
            : base(name, capacity)
        {
        }
    }
}
