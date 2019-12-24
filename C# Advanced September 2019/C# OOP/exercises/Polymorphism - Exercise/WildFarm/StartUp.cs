namespace WildFarm
{
    using IO;
    using Factory;

    public class StartUp
    {
        public static void Main()
        {
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();
            var engine = new Engine();
            var factory = new AnimalFactory();
            engine.Run(writer, reader,factory);
        }
    }
}
