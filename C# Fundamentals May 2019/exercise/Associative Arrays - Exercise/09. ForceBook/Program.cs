using System;
using System.Collections.Generic;
using System.Linq;
namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var userAndSide = new Dictionary<string, List<string>>();
            var input = string.Empty;
            while ((input= Console.ReadLine())!= "Lumpawaroo")
            {
                var line = new string[1];
                if (input.Contains("|"))
                {
                    line = input.Split(" | ");
                    var forceSide = line[0];
                    var forceUser = line[1];
                    if (!userAndSide.ContainsKey(forceSide))
                    {
                        userAndSide[forceSide] = new List<string>();
                        
                    }
                    if (!userAndSide[forceSide].Contains(forceUser)&&!userAndSide.Values.Any(x=>x.Contains(forceUser)))
                    {
                        userAndSide[forceSide].Add(forceUser);
                    }
                }
                else
                {
                    line = input.Split(" -> ");
                    var forceUser = line[0];
                    var forceSide = line[1];
                    // Side  - string
                    // user  - list
                    if (!userAndSide.Any(x=>x.Value.Contains(forceUser)))
                    {
                        if (!userAndSide.ContainsKey(forceSide))
                        {
                            userAndSide.Add(forceSide, new List<string>());
                        }
                        userAndSide[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                    else
                    {
                        foreach (var side in userAndSide)
                        {
                            if (side.Value.Contains(forceUser))
                            {
                                side.Value.Remove(forceUser);
                                break;
                            }
                        }

                        if (!userAndSide.ContainsKey(forceSide))
                        {
                            userAndSide.Add(forceSide, new List<string>());
                        }
                        userAndSide[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                }

            }
            foreach (var side in userAndSide.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count()}");
                foreach (var user in side.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }


        }
    }
}
