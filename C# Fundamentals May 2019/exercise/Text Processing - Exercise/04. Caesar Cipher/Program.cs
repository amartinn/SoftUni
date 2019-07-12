using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = (char)(input[i]+3);
                sb.Append(currentChar);  
            }
            Console.WriteLine(sb);
        }
    }
}
