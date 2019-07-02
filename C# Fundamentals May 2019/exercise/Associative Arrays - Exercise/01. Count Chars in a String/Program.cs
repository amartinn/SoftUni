using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> countChars = new Dictionary<char, int>();
            var input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];
                if (currentChar.Equals(' '))
                {
                    continue;
                }
                if (!countChars.ContainsKey(currentChar))
                {
                    countChars[currentChar] = 0;
                }
                countChars[currentChar]++;
            }
            foreach (var @char in countChars)
            {
                Console.WriteLine($"{@char.Key} -> {@char.Value}");
            }
        }
    }
}
