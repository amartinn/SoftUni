using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo(Environment.CurrentDirectory);
            var files = directory.GetFiles();
            var FilesByExtension = new Dictionary<string, Dictionary<string, long>>();
            foreach (var file in files)
            {
                var extension = file.Extension;
                var name = file.Name;
                var length = file.Length;
                if (!FilesByExtension.ContainsKey(extension))
                {
                    FilesByExtension[extension] = new Dictionary<string, long>();
                }
                FilesByExtension[extension].Add(name, length);
            }
            using (var writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ @"\report.txt"))
            {
                foreach (var extension in FilesByExtension.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
                {
                    writer.WriteLine(extension.Key);
                    foreach (var file in extension.Value.OrderBy(x=>x.Value))
                    { 
                        writer.WriteLine($"{file.Key} --- {file.Value/1000}kb");
                    }
                }
            }
            
        }
    }
}
