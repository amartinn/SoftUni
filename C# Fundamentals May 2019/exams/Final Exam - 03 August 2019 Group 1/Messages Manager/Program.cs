using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            var UsersAndSentMessages = new Dictionary<string, List<int>>();

            var capacity = int.Parse(Console.ReadLine());
            while ((input=Console.ReadLine())!="Statistics")
            {
                var splittedInput = input.Split("=");
                var command = splittedInput[0];
                if (command.Equals("Add"))
                {
                    var userName = splittedInput[1];
                    var sent = int.Parse(splittedInput[2]);
                    var received = int.Parse(splittedInput[3]);
                    if (!UsersAndSentMessages.ContainsKey(userName))
                    {
                        UsersAndSentMessages[userName] = new List<int>();
                        UsersAndSentMessages[userName].Add(sent);
                        UsersAndSentMessages[userName].Add(received);
                    }
                }
                else if (command.Equals("Message"))
                {
                    var sender = splittedInput[1];
                    var reciever = splittedInput[2];
                    if (UsersAndSentMessages.ContainsKey(sender) && UsersAndSentMessages.ContainsKey(reciever))
                    {
                        UsersAndSentMessages[sender][0]++;
                        if (UsersAndSentMessages[sender][0] + UsersAndSentMessages[sender][1]>=capacity)
                        {
                            Console.WriteLine($"{sender} reached the capacity!");
                            UsersAndSentMessages.Remove(sender);
                        }
                        UsersAndSentMessages[reciever][1]++;
                        if (UsersAndSentMessages[reciever][1] + UsersAndSentMessages[reciever][0] >= capacity)
                        {
                            Console.WriteLine($"{reciever} reached the capacity!");
                            UsersAndSentMessages.Remove(reciever);
                        }
                    }
                }
                else if (command.Equals("Empty"))
                {
                    var userName = splittedInput[1];
                    if (userName.Equals("All"))
                    {
                        UsersAndSentMessages = new Dictionary<string, List<int>>();
                    }
                    else
                    {
                        UsersAndSentMessages[userName] = new List<int>();
                    }
                }
            }
            Console.WriteLine($"Users count: {UsersAndSentMessages.Where(x=>x.Value.Count>0).ToDictionary(x=>x.Key,x=>x.Value).Count}");
            foreach (var user in UsersAndSentMessages
                .Where(x=>x.Value.Count>0)
                .OrderByDescending(x=>x.Value[1])
                .ThenBy(x=>x.Key))
            {
                var score = 0;

                foreach (var message in user.Value)
                {
                    score += message;
                }
                Console.WriteLine($"{user.Key} - {score}");
            }
        }
    }
}
