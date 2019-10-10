using System;
using System.Collections.Generic;
using System.IO;

namespace _04._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<byte>();
            using (var stream = new FileStream("softuni-logo.jpg",FileMode.Open))
            {
                using (var writer = new FileStream("output.jpg",FileMode.OpenOrCreate))
                {
                    byte[] buffer = new byte[1024];
                    var line = -1;
                    while ((stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
