using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsAndCount = new Dictionary<string, int>();
            using (var reader = File.OpenText("words.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var word = reader.ReadLine()
                        .ToLower();
                    wordsAndCount[word] = 0;
                }
            }
            using (var reader = File.OpenText("text.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine()
                        .ToLower()
                        .Split(new char[] { '-',' '});
                    foreach (var word in line)
                    {
                        if (wordsAndCount.ContainsKey(word))
                        {
                            wordsAndCount[word]++;
                        }
                    }
                   
                }
            }
            var output = new StringBuilder();
            foreach (var kvp in wordsAndCount)
            {
                output.AppendLine($"{kvp.Key} - {kvp.Value}");
                
            }

            File.WriteAllText("actualResult.txt", output.ToString());
            output = new StringBuilder();
            foreach (var kvp in wordsAndCount.OrderByDescending(x => x.Value))
            {
                output.AppendLine($"{kvp.Key} - {kvp.Value}");
            }
            File.WriteAllText("expectedResult.txt", output.ToString());
           
        }   
    }
}
