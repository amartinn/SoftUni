
namespace WildFarm
{
    using IO;
    using Factory;

    public interface IEngine
    {
        void Run(ConsoleWriter writer,ConsoleReader reader,AnimalFactory factory);
    }
}
