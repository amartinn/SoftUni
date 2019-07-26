using System;
using System.Collections.Generic;

namespace _01._String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            var resultString = string.Empty ;
            while ((input=Console.ReadLine())!="End")
            {
                var line = input.Split();
                var command = line[0];
                if (command=="Add")
                {
                    var stringToAdd = line[1];
                    resultString += stringToAdd;
                }
                else if (command=="Upgrade")
                {
                    var charToUpgrade = char.Parse(line[1]);
                    var tempString = string.Empty;
                    for (int i = 0; i < resultString.Length; i++)
                    {
                        if (resultString[i]==charToUpgrade)
                        {
                            tempString += (char)(charToUpgrade + 1);
                        }
                        else
                        {
                            tempString += resultString[i];
                        }
                    }
                    resultString = tempString;
                }
                else if (command=="Print")
                {
                    Console.WriteLine(resultString);
                }
                else if (command=="Index")
                {
                    var charToSearch = char.Parse(line[1]);
                    var indexList = new List<int>();
                    for (int i = 0; i < resultString.Length; i++)
                    {
                        if (resultString[i]==charToSearch)
                        {
                            indexList.Add(i);
                        }
                    }
                    if (indexList.Count!=0)
                    {
                        Console.WriteLine(string.Join(" ",indexList));
                    }
                    else
                    {
                        Console.WriteLine("None");
                    }
                }
                else if (command=="Remove")
                {
                    var stringToRemove = line[1];
                    while (resultString.Contains(stringToRemove))
                    {
                        resultString = resultString.Replace(stringToRemove, string.Empty);
                    }
    
                }
            }
        }
    }
}
