namespace BorderControl
{
    using Core.Contracts;
    using IO;
    using IO.Contracts;

    using System.Collections.Generic;
    public class StartUp
    {
        public static void Main()
        {
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();
            var birthdates = new List<string>();
            var engine = new Engine(reader, writer, birthdates);
            engine.Run();
            
        }
    }
}
