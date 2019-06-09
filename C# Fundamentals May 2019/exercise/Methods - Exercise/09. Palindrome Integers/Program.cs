using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
        }
        static void Init()
        {
            var input = Console.ReadLine();

            while (input != "END")
            {
                int inputAsInt = int.Parse(input);

                IsPalindrome(inputAsInt);
                input = Console.ReadLine();
            }
        }
        static void IsPalindrome(int number)
        {
            IEnumerable<char> forwards = number.ToString().ToCharArray();
            bool isPalindrome = forwards.SequenceEqual(forwards.Reverse());
            if (isPalindrome)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
         
        }
    }
}
