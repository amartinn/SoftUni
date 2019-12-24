namespace P01_RawData.Data
{
    using System;
    public class ConsoleDataReader : IConsoleDataReader
    {
        public string Read() => Console.ReadLine();
    }
}
