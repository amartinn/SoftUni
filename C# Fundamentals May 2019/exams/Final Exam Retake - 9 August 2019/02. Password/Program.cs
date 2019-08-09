using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Password
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"^(.+)>([0-9]{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<(\1)$";
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var match = Regex.Match(input, pattern);
                var sb = new StringBuilder();
                if (match.Success)
                {
                    sb.Append(match.Groups[2].Value);
                    sb.Append(match.Groups[3].Value);
                    sb.Append(match.Groups[4].Value);
                    sb.Append(match.Groups[5].Value);
                    Console.WriteLine($"Password: {sb.ToString()}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
