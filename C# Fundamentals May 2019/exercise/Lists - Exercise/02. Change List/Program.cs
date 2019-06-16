using System;
using System.Linq;

namespace _02._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            while (true)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];
                if (command=="end")
                {
                    Console.WriteLine(string.Join(" ",numbers));
                    return;
                }
                var value = int.Parse(input[1]);
                if (command=="Delete")
                {
                   
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i]==value)
                        {
                            numbers.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    var position = int.Parse(input[2]);
                    numbers.Insert(position, value);
                }
                
            }
        }
    }
}
