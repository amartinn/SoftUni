using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ThePartyReserve
{
    class Program
    {
        static Func<string, string, bool> startsWithFunc = (name, startsWithString) => name.StartsWith(startsWithString);
        static Func<string, string, bool> endsWithFunc = (name, endsWithString) => name.EndsWith(endsWithString);
        static Func<string, string, bool> lengthFunc = (name, length) => name.EndsWith(length);
        static Func<string, string, bool> containsFunc = (name, stringToContain) => name.Contains(stringToContain);
        static void Main(string[] args)
        {
            var guests = Console.ReadLine()
                .Split()
                .ToList();
            var filter = string.Empty;
            var conditions = Enumerable
                .Repeat(true, guests.Count)
                .ToList();
            while ((filter = Console.ReadLine()) != "Print")
            {
                var filterArgs = filter.Split(";");
                var command = filterArgs[0];
                var condition = filterArgs[1];
                var parameter = filterArgs[2];
                if (command == "Add filter")
                {
                    var temp = Operate(guests, condition, parameter);
                    for (int i = 0; i < guests.Count; i++)
                    {
                        for (int j = 0; j < temp.Count; j++)
                        {
                            if (temp[j]==guests[i])
                            {
                                conditions[i] = false;
                                continue;
                            }
                        }
                    }
                    ;
                }
                else
                {
                    var temp = Operate(guests, condition, parameter);
                    for (int i = 0; i < guests.Count; i++)
                    {
                        for (int j = 0; j < temp.Count; j++)
                        {
                            if (temp[j] == guests[i])
                            {
                                conditions[i] = true;
                                continue;
                            }
                        }
                    }
                }
            }
            var output = new List<string>();
            for (int i = 0; i < guests.Count; i++)
            {
                if (conditions[i] == true)
                {
                    output.Add(guests[i]);
                }
            }
            Console.WriteLine(string.Join(" ",output));
        }
        public static List<string> Operate(List<string> guests,string condition, string parameter)
        {
            var temp = new List<string>();
            if (condition == "Starts with")
            {
                temp = guests.Where(x => startsWithFunc(x, parameter)).ToList();

            }
            else if (condition == "Ends with")
            {
                temp = guests.Where(x => endsWithFunc(x, parameter)).ToList();
            }
            else if (condition == "Length")
            {
                temp = guests.Where(x => lengthFunc(x, parameter)).ToList();
            }
            else
            {
                temp = guests.Where(x => containsFunc(x, parameter)).ToList();
            }
            return temp;
        }
    }
}
