using System;
using System.Collections.Generic;
using System.Linq;

namespace Number_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var commandArgs = string.Empty;
            while ((commandArgs=Console.ReadLine())!="End")
            {
                var tokens = commandArgs.Split();
                var command = tokens[0];
                if (command.Equals("Switch"))
                {
                    var index = int.Parse(tokens[1]);
                    if (index>=0 && index<numbers.Count)
                    {
                        if (numbers[index]>0)
                        {
                            numbers[index] = -numbers[index];
                        }
                        else
                        {
                            numbers[index] = Math.Abs(numbers[index]);
                        }
                    }
                }
                else if (command.Equals("Change"))
                {
                    var index = int.Parse(tokens[1]);
                    var value = int.Parse(tokens[2]);
                    if(index >= 0 && index < numbers.Count)
                    {
                        numbers[index] = value;
                    }
                }
                else if (command.Equals("Sum"))
                {
                    var temp = tokens[1];
                    if (temp.Equals("Negative"))
                    {
                        var sum = 0;
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] < 0)
                            {
                                sum += numbers[i];
                            }
                        }
                        Console.WriteLine(sum);
                    }
                    else if (temp.Equals("Positive"))
                    {
                        var sum = 0;
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i]>0)
                            {
                                sum += numbers[i];
                            }
                        }
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        var sum = numbers.Sum();
                        Console.WriteLine(sum) ;
                    }
                }
                

            }
            var result = new List<int>();
            foreach (var number in numbers)
            {
                if (number >= 0)
                {
                    result.Add(number);
                }
            }
            Console.WriteLine(string.Join(" ", result));

        }
    }
}
