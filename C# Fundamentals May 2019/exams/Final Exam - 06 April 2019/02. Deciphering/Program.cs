using System;
using System.Text.RegularExpressions;

namespace _02._Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            var encryptedString = Console.ReadLine();
            var substrings = Console.ReadLine().Split();
            var decryptedString = string.Empty;
            var pattern = @"^[{}|#d-z]+$";
            var match = Regex.Match(encryptedString, pattern);
            if (match.Success)
            {
                foreach (var @char in encryptedString)
                {
                    decryptedString += (char)(@char - 3);
                }
                decryptedString = decryptedString.Replace(substrings[0], substrings[1]);
                Console.WriteLine(decryptedString);
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
            
        }
    }
}
