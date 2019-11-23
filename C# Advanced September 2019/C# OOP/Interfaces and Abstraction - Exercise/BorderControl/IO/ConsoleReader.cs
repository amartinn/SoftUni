namespace BorderControl.IO.Contracts
{
    using Contracts;
    using System;
    public  class ConsoleReader : IConsoleReader
    {
        public string Read() => Console.ReadLine();

    }
}
