
namespace P01_RawData.Data
{
    using System;
    public class ConsoleDataWriter : IConsoleDataWriter
    {
        public void Write(object obj) => Console.WriteLine(obj);

    }
}
