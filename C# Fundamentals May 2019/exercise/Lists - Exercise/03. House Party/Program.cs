using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = int.Parse(Console.ReadLine());
            var people = new List<string>();
            for (int i = 0; i < length; i++)
            {
                var message = Console.ReadLine().Split();
                var name = message[0];
                if (people.Contains(name) && message.Length==3)
                {
                    Console.WriteLine($"{name} is already in the list!");
                    continue;
                }
                if (message.Length==3)
                {
                   
                        people.Add(name);
                   
                }
                else
                {
                    if (!people.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                    else
                    {
                        people.Remove(name);
                    }
                }
               
            }
            foreach (var guest in people)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
