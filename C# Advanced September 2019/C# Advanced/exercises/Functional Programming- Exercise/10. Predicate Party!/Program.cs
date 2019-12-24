using System;
using System.Linq;
using System.Collections.Generic;
namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var visitors = Console.ReadLine()
                .Split()
                .ToList();
            Func<string, string, bool> startsWithFunc = (name, startsWithString) => name.StartsWith(startsWithString);
            Func<string, string, bool> endsWithFunc = (name, endsWithString) => name.EndsWith(endsWithString);
            Func<string, int, bool> lengthFunc = (name, len) => name.Length == len;
            var line = string.Empty;
            while ((line=Console.ReadLine())!="Party!")
            {
                var commandArgs = line.Split();
                var command = commandArgs[0];
                var keyWord = commandArgs[1];
                var parameter = commandArgs[2];
                if (command=="Double")
                {
                    var temp = new List<string>();
                    if (keyWord == "StartsWith")
                    {
                        temp = visitors
                            .Where(x => startsWithFunc(x, parameter))
                            .ToList();
                    }
                    else if (keyWord == "EndsWith")
                    {
                        temp = visitors
                           .Where(x => endsWithFunc(x, parameter))
                           .ToList();
                    }
                    else
                    {
                        var length = int.Parse(parameter);
                         temp = visitors
                            .Where(x=>lengthFunc(x,length))
                            .ToList();
                      
                    }
                    foreach (var currentName in temp)
                    {
                        var index = visitors.IndexOf(currentName);
                       visitors.Insert(index, currentName);
                    }
                }
                else
                {
                    if (keyWord == "StartsWith")
                    {
                        visitors = visitors
                            .Where(x => !startsWithFunc(x, parameter))
                            .ToList();
                    }
                    else if (keyWord == "EndsWith")
                    {
                        visitors = visitors
                           .Where(x => !endsWithFunc(x, parameter))
                           .ToList();
                    }
                    else
                    {
                        var length = int.Parse(parameter);
                        visitors = visitors
                           .Where(x => !lengthFunc(x, length))
                           .ToList();
                    }
                }

            }
            if (visitors.Count> 0)
            {
                Console.WriteLine($"{string.Join(", ", visitors)} are going to the party!");
            }
            else
            {
                Console.WriteLine($"Nobody is going to the party!");
            }

        }
    }
}
