namespace WildFarm.IO
{
    using System;
    public class ConsoleReader : IConsoleReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
