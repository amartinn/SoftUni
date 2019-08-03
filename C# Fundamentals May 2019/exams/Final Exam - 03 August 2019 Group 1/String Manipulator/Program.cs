using System;
using System.Text;
using System.Linq;
namespace String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var line = string.Empty;
            while ((line=Console.ReadLine())!="End")
            {
                var lineArgs = line.Split();
                var command = lineArgs[0];
                if (command.Equals("Translate"))
                {
                    var charToReplace = char.Parse(lineArgs[1]);
                    var replacement = char.Parse(lineArgs[2]);
                    input = input.Replace(charToReplace, replacement);
                    Console.WriteLine(input);
                }
                else if (command.Equals("Includes"))
                {
                    var strToInclude = lineArgs[1];
                    if (input.Contains(strToInclude))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command.Equals("Start"))
                {
                    var strToStart = lineArgs[1];
                    if (input.StartsWith(strToStart))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command.Equals("Lowercase"))
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                }
                else if (command.Equals("FindIndex"))
                {
                    var charToSearch = char.Parse(lineArgs[1]);
                    if (input.Contains(charToSearch))
                    {
                        Console.WriteLine(input.LastIndexOf(charToSearch));
                    }
                }
                else if (command.Equals("Remove"))
                {
                    var startIndex = int.Parse(lineArgs[1]);
                    var count = int.Parse(lineArgs[2]);
                    input = input.Remove(startIndex, count);
                    Console.WriteLine(input);

                    
                }
            }
        }
    }
}
