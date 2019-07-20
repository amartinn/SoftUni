using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _06._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailPattern = @"(?<=\s)([a-z]+|\d+)(\d+|\w+|\.+|-+)([a-z]+|\d+)\@[a-z]+\-?[a-z]+\.[a-z]+(\.[a-z]+)?";
            var input = Console.ReadLine();
            var regex = new Regex(emailPattern);
            var matches = regex.Matches(input);
            var emails = new List<string>();
            foreach (var match in matches)
            {
                emails.Add(match.ToString());
            }
            Console.WriteLine(string.Join(Environment.NewLine,emails));

        }
    }
}
