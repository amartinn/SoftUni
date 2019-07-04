using System;
using System.Collections.Generic;
using System.Linq;
namespace _01._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestAndPwd = new Dictionary<string, string>();
            var input = string.Empty;
            var userContestAndPts = new Dictionary<string, Dictionary<string, int>>();
            while ((input=Console.ReadLine())!= "end of contests")
            {
                var line = input.Split(":");
                var contest = line[0];
                var password = line[1];
                contestAndPwd.Add(contest, password);
            }
            while ((input=Console.ReadLine())!= "end of submissions")
            {
                var line = input.Split("=>");
                var contest = line[0];
                var pwd = line[1];
                var user = line[2];
                var pts = int.Parse(line[3]);
                foreach (var kvp in contestAndPwd)
                {
                    if (kvp.Key==contest && kvp.Value==pwd)
                    {
                        if (!userContestAndPts.ContainsKey(user))
                        {
                            userContestAndPts[user] = new Dictionary<string, int>();
                            userContestAndPts[user].Add(contest, pts);

                        }
                       else if (userContestAndPts.ContainsKey(user) && userContestAndPts[user].ContainsKey(contest))
                        {
                            if (userContestAndPts[user][contest]<pts)
                            {
                                userContestAndPts[user][contest] = pts;
                            }
                           
                            
                        }
                        else
                        {
                            userContestAndPts[user].Add(contest, pts);
                        }
                        
                      
                        break;                     
                    }
                }
            }
            var bestUser = string.Empty;
            var bestPts = int.MinValue;
            foreach (var users in userContestAndPts)
            {
                var sum = 0;
                var currentUser = users.Key;
                foreach (var contests in users.Value)
                {
                    
                    sum += contests.Value;
                        
                }
                if (sum>bestPts)
                {
                    bestUser = currentUser;
                    bestPts = sum;
                }
            }
            Console.WriteLine($"Best candidate is {bestUser} with total {bestPts} points.");
            Console.WriteLine("Ranking: ");
            foreach (var users in userContestAndPts.OrderBy(x=>x.Key))
            {
                Console.WriteLine(users.Key);
                foreach (var contests in users.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contests.Key} -> {contests.Value}");
                }
            }
        }
    }
}
