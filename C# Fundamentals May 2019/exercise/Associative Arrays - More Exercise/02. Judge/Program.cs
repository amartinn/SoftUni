using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://judge.softuni.bg/Contests/Practice/Index/1302#1
            var contestUserAndPts = new Dictionary<string, Dictionary<string, int>>();
            var input = string.Empty;
            while ((input = Console.ReadLine())!="no more time")
            {
                var line = input.Split(" -> ");
                var user = line[0];
                var contest = line[1];
                var pts = int.Parse(line[2]);            
                if (!contestUserAndPts.ContainsKey(contest))
                {
                    contestUserAndPts[contest] = new Dictionary<string, int>();
                    contestUserAndPts[contest].Add(user, pts);
                   
                }
                else if (contestUserAndPts.ContainsKey(contest) && !contestUserAndPts[contest].ContainsKey(user))
                {
                 
                    contestUserAndPts[contest].Add(user, pts);
                    
                }
                 if (contestUserAndPts.ContainsKey(contest) && contestUserAndPts[contest].ContainsKey(user))
                {
                    if (contestUserAndPts[contest][user]<pts)
                    {
                        contestUserAndPts[contest][user] = pts;
                           
                    }
                    
                }   
            }
            
            foreach (var contest in contestUserAndPts)
        {
            Console.WriteLine($"{contest.Key}: {contest.Value.Keys.Count} participants");
            foreach (var users in contest.Value.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                var count = 1;
                Console.WriteLine($"{count}. {users.Key} <::> {users.Value}");
                count++;
            }
        }
            Console.WriteLine("Individual standings:"); 
            // TODO
        }
    }
}
