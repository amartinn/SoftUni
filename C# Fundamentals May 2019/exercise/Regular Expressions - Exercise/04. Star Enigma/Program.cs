using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var encriptionPattern = @"[starSTAR]";
            var planetsPattern = @"@([A-Z][a-z]+)(?:[^@\-!:>]*):(\d+)(?:[^@\-!:>]*)!(A|D{1})!(?:[^@\-!:>]*)->(\d+)";
            var attackedPlanets = new List<string>();
            var destroyedPlanets = new List<string>();
            for (int i = 0; i < n; i++)
            {
            var input = Console.ReadLine();
            var regex = new Regex(encriptionPattern);
            var match = regex.Matches(input);
            var sb = new StringBuilder();
            for (int j   = 0; j < input.Length; j++)
            {
                sb.Append((char)(input[j] - match.Count));
            }
                regex = new Regex(planetsPattern);
                var currentEncryptedMessage = sb.ToString();
                var encryptedMatch = regex.Match(currentEncryptedMessage);
                var planetName = encryptedMatch.Groups[1].Value;
                var destroyedOrAttacked = encryptedMatch.Groups[3].Value;
                if (destroyedOrAttacked.Equals("A") && planetName!=null)
                {
                    attackedPlanets.Add(planetName);
                }
                else if (destroyedOrAttacked.Equals("D") && planetName != null)
                {
                    destroyedPlanets.Add(planetName);
                }
            }
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var planet in attackedPlanets.OrderBy(x=>x))
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var planet in destroyedPlanets.OrderBy(x=>x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}   
