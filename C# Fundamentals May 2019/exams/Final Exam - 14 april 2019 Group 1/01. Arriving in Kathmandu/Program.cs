using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._Arriving_in_Kathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"^(?<name>[A-Za-z!@#$?]+)=(?<lenght>\d+)<<(?<code>(.*?)+)$";
            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Last note")
            {
                var match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    var lenght = int.Parse(match.Groups["lenght"].Value);
                    var name = string.Empty;
                    var codeLenght = match.Groups["code"].Length;
                    if (codeLenght==lenght)
                    {
                        foreach (var @char in match.Groups["name"].Value)
                        {
                            if (char.IsLetterOrDigit(@char))
                            {
                                name += @char;
                            }
                        }
                        var geohashcode = match.Groups["code"].Value;
                        Console.WriteLine($"Coordinates found! {name} -> {geohashcode}");
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }


            }

        }
    }
}
