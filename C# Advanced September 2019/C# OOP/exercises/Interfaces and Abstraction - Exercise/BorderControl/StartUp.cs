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
            var citizens = new Dictionary<string, ICitizen>();
            var engine = new Engine(reader, writer, citizens);
            engine.Run();
            
        }
    }
}
