using System;
using System.Collections.Generic;
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
                            if (i % 4 == 0 && i != 0)
                            {
                                result += '-';
                            }
                            else if (char.IsDigit(key[i]))
                            {
                                var digit = int.Parse(key[i].ToString());
                                result += Math.Abs(9 - digit);
                            }

                            var current = key[i];
                            result += char.ToUpper(current);


                        }
                        keys.Add(result);
                    }
                    else if (key.Length == 25)
                    {
                        for (int i = 0; i < key.Length; i++)
                        {
                            if (i % 5 == 0 && i != 0)
                            {
                                Console.WriteLine(i);
                                result += '-';
                            }
                            else
                            {

                                if ((char.IsDigit(key[i])))
                            
                                {
                                    var digit = int.Parse(key[i].ToString());
                                    result += Math.Abs(9 - digit);
                                }
                                else
                                {
                                    var current = key[i];
                                    result += char.ToUpper(current);
                                }
                                
                            }

                            

                        }
                        keys.Add(result);
                    }
                }

            }
            Console.WriteLine(string.Join(',', keys));
        }
    }
}
