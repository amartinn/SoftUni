using System;

namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalChars = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < totalChars; i++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                sum += (int)currentChar;
            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
