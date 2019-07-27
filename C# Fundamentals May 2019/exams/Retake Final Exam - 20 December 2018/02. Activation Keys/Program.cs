using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO
            var input = Console.ReadLine().Split("&");
            var keys = new List<string>();
            foreach (var key in input)
            {
                var result = string.Empty;
                if (Regex.IsMatch(key, @"^[0-9a-zA-Z]+$"))
                {
                    if (key.Length == 16)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            var current = key[i];
                            if (i % 4 == 0 && i != 0)
                            {
                                result += "-";
                            }
                            if (char.IsDigit(current))
                            {
                                result += (int)(9 - int.Parse(current.ToString()));
                            }
                            else if (char.IsLetter(current))
                            {
                                result += char.ToUpper(current);
                            }
                        }
                        keys.Add(result);
                    }
                    else if (key.Length == 25)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            var current = key[i];
                            if (i % 5 == 0 && i != 0)
                            {
                                result += "-";
                            }
                            if (char.IsDigit(current))
                            {
                                result += (int)(9 - int.Parse(current.ToString()));
                            }
                            else if (char.IsLetter(current))
                            {
                                result += char.ToUpper(current);
                            }
                        }
                    }
                    keys.Add(result);
                }
            }
            Console.WriteLine(string.Join(", ", keys.Distinct()));
        }

    }
}
