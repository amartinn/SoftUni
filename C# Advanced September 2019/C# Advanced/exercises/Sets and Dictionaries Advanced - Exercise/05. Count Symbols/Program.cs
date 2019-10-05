using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputWord = Console.ReadLine();
            var symbolsAndCount = new Dictionary<char, int>();
            for (int i = 0; i < inputWord.Length; i++)
            {
                var currentChar = inputWord[i];
                if (!symbolsAndCount.ContainsKey(currentChar))
                {
                    symbolsAndCount[currentChar] = 0;
                }
                symbolsAndCount[currentChar]++;
            }
            foreach (var @char in symbolsAndCount.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{@char.Key}: {@char.Value} time/s");
            }
        }
    }
}
