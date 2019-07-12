using System;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { '\\', '.' });
            var fileName = input[input.Length - 2];
            var extension = input[input.Length-1];
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
