using System;

namespace _2._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine().ToLower();
            VowelCount(word);
            Console.WriteLine(VowelCount(word));
        }
        static int VowelCount(string word)
        {
            var countOfVowels = 0;  
            for (int i = 0; i < word.Length; i++)
            {
                var current = word[i].ToString();
                if ("aeiou".Contains(current))
                {
                    countOfVowels++;
                   
                }
            }
            return countOfVowels;
        }
    }
}
