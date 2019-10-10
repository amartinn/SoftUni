using System;
using System.IO;
using System.Text;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var lineCounter = 1;
            var builder = new StringBuilder();
            using (var reader = File.OpenText("text.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var counterOfWords = 0;
                    var counterOfPunctoationMarks = 0;
                    for (int i = 0; i < line.Length; i++)
                    {
                        var currentSymbol = line[i];
                        if (currentSymbol != ' ' && char.IsLetter(currentSymbol))
                        {
                            counterOfWords++;
                        }
                        else if (char.IsPunctuation(currentSymbol))
                        {
                            counterOfPunctoationMarks++;
                        }
                    }
                    builder.AppendLine($"Line {lineCounter}: {line} ({counterOfWords})({counterOfPunctoationMarks})");
                    lineCounter++;
                }
            }
            File.WriteAllText("output.txt", builder.ToString());
        }
    }
}
