using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var geoHashCode = new StringBuilder();
            var nameOfRacer = string.Empty;
            var isValid = false;
            while (!isValid)
            {
                var input = Console.ReadLine();
                var lenghtPattern = @"=(\d+)!!";
                var lenghtMatch = Regex.Match(input, lenghtPattern);
                if (lenghtMatch.Success)
                {
                    var pattern = $@"([$%*&#])(\w+)(\1)=(\d+)!!(.{{{lenghtMatch.Groups[1].Value}}})$";
                    var match = Regex.Match(input, pattern);
                    if (match.Success)
                    {
                        nameOfRacer = match.Groups[2].Value;
                        var coordinates = match.Groups[5].Value;
                        var lenght = int.Parse(lenghtMatch.Groups[1].Value);
                        foreach (var cord in coordinates)
                        {
                            geoHashCode.Append((char)(cord+lenght));
                        }
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine($"Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine($"Nothing found!");
                }


            }
            Console.WriteLine($"Coordinates found! {nameOfRacer} -> {geoHashCode.ToString()}");
            }
    }
}
