
namespace Vehicles.IO
{
    using System;

    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
