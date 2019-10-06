using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    public class Program
    {
        static void Main(string[] args)
        {


            var candidates = new Dictionary<string, Dictionary<string, int>>();
            var contestAndPassword = new Dictionary<string, string>();
            var command = string.Empty;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                var commandArgs = command.Split(":");
                var contest = commandArgs[0];
                var password = commandArgs[1];
                if (!contestAndPassword.ContainsKey(contest))
                {
                    contestAndPassword[contest] = password;
                }
            }
            while ((command = Console.ReadLine()) != "end of submissions")
            {
                var commandArgs = command.Split("=>");
                var contest = commandArgs[0];
                var password = commandArgs[1];
                var user = commandArgs[2];
                var points = int.Parse(commandArgs[3]);
               if (contestAndPassword.ContainsKey(contest))
               {
                   if (contestAndPassword[contest] == password)
                   {
                       if (!candidates.ContainsKey(user))
                       {
                           candidates[user] = new Dictionary<string, int>
                           {
                               { contest, points }
                           };
                       }
                       else if (candidates[user].ContainsKey(contest))
                       {
                           if (candidates[user][contest] < points)
                           {
                               candidates[user][contest] = points;
                           }
                       }
                       else
                       {
                           candidates[user].Add(contest, points);
                       }
                   }
               }
            }
            var bestCandidate = string.Empty;
            var bestPointsSum = int.MinValue;

            foreach (var candidate in candidates)
            {
                var currentPts = candidate.Value.Values.Sum();
                if (currentPts > bestPointsSum)
                {
                    bestPointsSum = currentPts;
                    bestCandidate = candidate.Key;
                }

            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestPointsSum} points.");
            Console.WriteLine("Ranking:");

            foreach (var candidate in candidates.OrderBy(x => x.Key))
            {
                Console.WriteLine(candidate.Key);
                foreach (var course in candidate.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {course.Key} -> {course.Value}");
                }
            }
        }
    }
}
