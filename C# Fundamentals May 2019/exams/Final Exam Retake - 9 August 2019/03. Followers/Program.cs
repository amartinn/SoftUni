using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            var followers = new Dictionary<string, List<int>>();
            // 0 -> like
            // 1 -> comment
            var input = string.Empty;
            while ((input=Console.ReadLine())!="Log out")
            {
                var inputArgs = input.Split(": ");
                var command = inputArgs[0];
                var username = inputArgs[1];
                if (command.Equals("New follower"))
                {
                    if (!followers.ContainsKey(username))
                    {
                        followers[username] = new List<int>();
                        followers[username].Add(0); //-> like
                        followers[username].Add(0); // -> comment
                    }
                   
                }
                else if (command.Equals("Like"))
                {
                    var count = int.Parse(inputArgs[2]);
                    if (followers.ContainsKey(username))
                    {
                        followers[username][0] += count;
                    }
                    else
                    {
                        followers[username] = new List<int>();
                        followers[username].Add(count);
                        followers[username].Add(0);
                    }
                }
                else if (command.Equals("Comment"))
                {
                    if (followers.ContainsKey(username))
                    {
                        followers[username][1] += 1;
                    }
                    else
                    {
                        followers[username] = new List<int>();
                        followers[username].Add(0);
                        followers[username].Add(1);
                    }
                }
                else if (command.Equals("Blocked"))
                {
                    if (followers.ContainsKey(username))
                    {
                        followers.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }
            }
            Console.WriteLine($"{followers.Keys.Count} followers");
            foreach (var user in followers.OrderByDescending(x=>x.Value[0]).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{user.Key}: {user.Value.Sum()}");
            }
        }
    }
}
