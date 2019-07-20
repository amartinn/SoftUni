using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(", ");
            var namesAndScore = new Dictionary<string, double>();
            foreach (var name in names)
            {
                namesAndScore[name] = 0;
            }
            var namePattern = @"[a-zA-Z]+";
            var nameRegex = new Regex(namePattern);
            var scorePattern = @"\d";
            var scoreRegex = new Regex(scorePattern);
            var input  = string.Empty;
            while ((input=Console.ReadLine())!="end of race")
            {
                var nameMatches = nameRegex.Matches(input);
                var sb = new StringBuilder();
                foreach (var match in nameMatches)
                {
                    sb.Append(match);
                }
                if (namesAndScore.ContainsKey(sb.ToString()))
                {
                 
                    var scoreMatches = scoreRegex.Matches(input);
                    var score = 0.0;
                    foreach (var match in scoreMatches)
                    {   
                        score += double.Parse(match.ToString());   
                    }
                    namesAndScore[sb.ToString()] += score;
                }
            }
            namesAndScore = namesAndScore
                .OrderByDescending(p => p.Value)
                .Take(3)
                .ToDictionary(k=>k.Key,v=>v.Value);
            Console.WriteLine($"1st place: {namesAndScore.FirstOrDefault().Key}");
            Console.WriteLine($"2nd place: {namesAndScore.Skip(1).Take(1).FirstOrDefault().Key}");
            Console.WriteLine($"3rd place: {namesAndScore.LastOrDefault().Key}");
        }  
    }
}
