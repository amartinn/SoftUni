namespace FoodShortage
{

    using Factory;
    using Core;
    using IO;

    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var citizenFactory = new CitizenFactory();
            var rebelFactory = new RebelFactory();
            var citizens = new Dictionary<string, Citizen>();
            var engine = new Engine(writer,reader,citizenFactory,rebelFactory,citizens);
            engine.Run();
        }
    }
}
