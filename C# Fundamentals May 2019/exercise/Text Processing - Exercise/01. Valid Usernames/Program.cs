using System;
using System.Collections.Generic;
using System.Linq;
namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var userNames = Console.ReadLine().Split(", ");
            var valid = new List<string>(); 
            foreach (var name in userNames)
            {
                if (name.Length>=3 && name.Length<=16)
                {
                    var count = 0;
                    for (int i = 0; i < name.Length; i++)
                    {
                        var currentChar = name[i];
                        if (char.IsDigit(currentChar) || char.IsLetter(currentChar) || currentChar == '-' || currentChar =='_')
                        {
                            count++;
                        }
                    }
                    if (count==name.Length)
                    {
                        valid.Add(name);
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }
            foreach (var user in valid)
            {
                Console.WriteLine(user);
            }
        }
    }
}
