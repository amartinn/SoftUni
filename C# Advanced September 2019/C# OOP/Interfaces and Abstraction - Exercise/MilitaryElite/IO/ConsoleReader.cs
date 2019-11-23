namespace MilitaryElite.IO
{
    using System;
    using Contracts;
    class ConsoleReader : IConsoleReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
