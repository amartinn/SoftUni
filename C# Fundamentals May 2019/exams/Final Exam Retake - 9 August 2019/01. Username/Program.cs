using System;
using System.Linq;
using System.Text;

namespace _01._Username
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var input = string.Empty;
            while ((input=Console.ReadLine())!= "Sign up")
            {
                var inputArgs = input.Split();
                var command = inputArgs[0];
                if (command.Equals("Case"))
                {
                    var commandArgs = inputArgs[1];
                    if (commandArgs.Equals("lower"))
                    {
                        word = word.ToLower();
                    }
                    else
                    {
                        word = word.ToUpper();
                    }
                    Console.WriteLine(word);
                }
                else if (command.Equals("Reverse"))
                {
                    var startIndex = int.Parse(inputArgs[1]);
                    var endIndex = int.Parse(inputArgs[2]);
                    if (startIndex < 0 || endIndex>= word.Length)
                    {
                        continue;
                    }
                    //ThisIsMyString
                    // 1 4
                    var sb = new StringBuilder();
                    for (int i = endIndex; i >= startIndex; i--)
                    {
                        sb.Append(word[i]);
                    }
                    Console.WriteLine(sb.ToString());
                    
                }
                else if (command.Equals("Cut"))
                {
                    var substring = inputArgs[1];
                    if (word.Contains(substring))
                    {
                        word = word.Replace(substring, string.Empty);
                        Console.WriteLine(word);
                    }
                    else
                    {
                        Console.WriteLine($"The word {word} doesn't contain {substring}.");
                    }
                }
                else if (command.Equals("Replace"))
                {
                    var charToReplace = char.Parse(inputArgs[1]);
                    word = word.Replace(charToReplace, '*');
                    Console.WriteLine(word);
                }
                else if (command.Equals("Check"))
                {
                    var charToContain = char.Parse(inputArgs[1]);
                    if (word.Contains(charToContain))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {charToContain}.");
                    }
                }
            }
        }
    }
}
