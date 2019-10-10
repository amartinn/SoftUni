using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = 0;

            var symbolsToReplace = new char[] { '-', ',', '.', '!', '?' };
            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    var words = line.Split();
                    var output = new List<string>();
                    if (counter%2==0)
                    {
                        foreach (var word in words)
                        {
                            var outputWord = "";
                            for (int i = 0; i < word.Length; i++)
                            {
                                var add = word[i];
                                if (symbolsToReplace.Contains(add))
                                {
                                    add = '@';
                                }
                                outputWord += add;
                            }
                            output.Add(outputWord);

                        }
                        output.Reverse();
                        Console.WriteLine(string.Join(" ", output));
                    }
                    counter++;
                }
            }

        }
    }
 
}
