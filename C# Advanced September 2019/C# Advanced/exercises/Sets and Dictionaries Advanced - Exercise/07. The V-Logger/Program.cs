using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    public class Vlogger
    {
        public List<string> Followers { get; set; }
        public List<string> Following { get; set; }
        public string Name { get; set; }
        public Vlogger(string name)
        {
            this.Name = name;
            this.Followers = new List<string>();
            this.Following = new List<string>();
        }
        public override string ToString()
        {
            return $"{this.Name} : {this.Followers.Count} followers, {this.Following.Count} following";
        }
    }
    public class Program
    {
        static int counter = 0;
        static void Main(string[] args)
        { 
            var vloggers = new Dictionary<string, Vlogger>();
            var command = string.Empty;
            while ((command=Console.ReadLine())!= "Statistics")
            {
               var  commandArgs = command.Split();
                var userName = commandArgs[0];
                var state = commandArgs[1];
                if (state=="joined")
                {

                    if (!vloggers.ContainsKey(userName))
                    {
                        vloggers[userName] = new Vlogger(userName);
                    }
                    
                }
                else
                {
                    var userToFollow = commandArgs[2];

                    if (vloggers.ContainsKey(userName)&& userName!=userToFollow && vloggers.ContainsKey(userToFollow))
                    {
                        if (!vloggers[userName].Following.Contains(userToFollow))
                        {
                            vloggers[userName].Following.Add(userToFollow);
                        }                      
                    }
                    if (vloggers.ContainsKey(userToFollow) && userName!=userToFollow&&vloggers.ContainsKey(userName))
                    {
                        if (!vloggers[userToFollow].Followers.Contains(userName))
                        {
                            vloggers[userToFollow].Followers.Add(userName);
                        }
                    }
                }
                
            }
             
            Console.WriteLine($"The V-Logger has a total of {vloggers.Keys.Count} vloggers in its logs.");
            var maxFollowersCount = int.MinValue;
            Vlogger mostFamousVlogger = null;
            var mostFamousVloggerUsername = string.Empty;
            
            foreach (var vlogger in vloggers)
            {
                var currentVloggerFollowers = vlogger
                    .Value
                    .Followers
                    .Count;
                if (maxFollowersCount<currentVloggerFollowers)
                {
                    maxFollowersCount = currentVloggerFollowers;
                    mostFamousVloggerUsername = vlogger.Key;
                    mostFamousVlogger = vlogger.Value;
                    mostFamousVlogger.Name = mostFamousVloggerUsername;
                }
            }
            var counter = 1;
            Console.WriteLine($"{counter}. " + mostFamousVlogger.ToString());
            foreach (var follower in mostFamousVlogger.Followers.OrderBy(x=>x))
            {
                Console.WriteLine($"*  {follower}");
            }

            foreach (var vlogger in vloggers.OrderByDescending(x=>x.Value.Followers.Count).ThenBy(x=>x.Value.Following.Count))
            {
                if (vlogger.Value.Name==mostFamousVlogger.Name)
                {
                    continue;
                }
                var currentVloggerName = vlogger.Value.Name;
                var currentVloggerFollowersCount = vlogger
                    .Value
                    .Followers
                    .Count;
                var currentVloggerFollowingCount = vlogger
                    .Value
                    .Following
                    .Count;
                counter++;
                Console.WriteLine($"{counter}. {currentVloggerName} : {currentVloggerFollowersCount} followers, {currentVloggerFollowingCount} following");
               
            }

        }
    }
}
