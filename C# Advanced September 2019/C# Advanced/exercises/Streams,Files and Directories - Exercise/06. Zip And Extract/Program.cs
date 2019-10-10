using System;
using System.IO.Compression;

namespace _06._Zip_And_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"../../../copyMe", "copyMe.zip");
            ZipFile.ExtractToDirectory("copyMe.zip", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Extracted");
        }
    }
}
