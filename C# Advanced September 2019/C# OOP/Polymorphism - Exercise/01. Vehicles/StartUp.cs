

namespace Vehicles
{

    using Factory;
    using IO;
    public class StartUp
    {
        public static void Main()
        {
            Engine engine = new Engine();
            var factory = new VehicleFactory();
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();
            engine.Run(factory,writer,reader);
        }
    }
}
