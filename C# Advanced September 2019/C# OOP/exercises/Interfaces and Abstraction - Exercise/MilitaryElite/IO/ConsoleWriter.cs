namespace MilitaryElite.IO
{
    using System;
    using Contracts;
    class ConsoleWriter : IConsoleWriter
    {
        public void Write(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
