namespace Vehicles
{
    using Factory;
    using IO;
    public interface IEngine
    {
        void Run(VehicleFactory factory, IConsoleWriter writer, IConsoleReader reader);
    }
}
