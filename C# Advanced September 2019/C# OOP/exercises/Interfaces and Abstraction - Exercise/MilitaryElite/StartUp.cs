namespace MilitaryElite
{
    using Core;
    using IO;
    using Entities.Contracts;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();
            var soldiers = new Dictionary<int, ISoldier>();
            var engine = new Engine(reader, writer,soldiers);
            engine.Run();
        }
    }
}
