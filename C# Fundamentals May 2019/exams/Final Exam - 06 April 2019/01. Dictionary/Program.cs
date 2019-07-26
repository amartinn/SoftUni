using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var termAndDescription = new Dictionary<string, List<string>>();

            var firstLine = Console.ReadLine()
                .Split(" | "
                ,StringSplitOptions.RemoveEmptyEntries);

            var secondLine = Console.ReadLine()
                .Split(" | "
                , StringSplitOptions.RemoveEmptyEntries);

            var thirdLine = Console.ReadLine();

            var words = new List<string>();

            foreach (var sentance in firstLine)
            {
                var line  = sentance.Split(": ");
                var term = line[0];
                var description = line[1];
                if (!termAndDescription.ContainsKey(term))
                {
                    termAndDescription[term] = new List<string>();
                }
                termAndDescription[term].Add(description);
            }
            foreach (var word in secondLine)
            {
                words.Add(word);
            }
            if (thirdLine=="List")
            {
                termAndDescription = termAndDescription
                    .OrderBy(x => x.Key)
                    .ToDictionary(k => k.Key, v => v.Value);
                Console.WriteLine(string.Join(" ",termAndDescription.Keys));
            }
            else
            {
                words = words.Distinct().ToList();
                foreach (var term in termAndDescription.Distinct().OrderBy(x=>x.Key))
                {
                    if (words.Contains(term.Key))
                    {
                        Console.WriteLine(term.Key);
                        foreach (var description in term.Value.OrderByDescending(x => x.Length))
                        {
                            Console.WriteLine($"-{description}");
                        }
                    }
                }
            }
        }
    }
}
