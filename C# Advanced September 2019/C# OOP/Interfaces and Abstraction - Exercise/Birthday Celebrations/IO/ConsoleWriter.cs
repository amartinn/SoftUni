namespace BorderControl.IO
{
    using Contracts;
    using System;

    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(object obj) => Console.WriteLine(obj);
    }
}
