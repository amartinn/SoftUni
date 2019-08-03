using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"(^[%$]{1})([A-Z][a-z]+)\1: \[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|$";

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    var name = match.Groups[2].Value;
                    if (name.Length<3)
                    {
                        Console.WriteLine("Valid message not found!");
                        continue;
                    }
                    var firstDigit = int.Parse(match.Groups[3].Value);
                    var secondDigit = int.Parse(match.Groups[4].Value);
                    var thirdDigit = int.Parse(match.Groups[5].Value);
                    var sb = new StringBuilder();
                    sb.Append((char)firstDigit);
                    sb.Append((char)secondDigit);
                    sb.Append((char)thirdDigit);
                    Console.WriteLine($"{name}: {sb.ToString()}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
