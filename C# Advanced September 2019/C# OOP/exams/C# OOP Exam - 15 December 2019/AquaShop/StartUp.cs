namespace AquaShop
{
    using System;

    using AquaShop.Core;
    using AquaShop.Core.Contracts;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Fish;
    using AquaShop.Repositories;

    public class StartUp
    {
        public static void Main()
        {
          
           IEngine engine = new Engine();
           engine.Run();
          
        }
    }
}
