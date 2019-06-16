using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            var specialNumber = input[0];
            var specialNumberPower = input[1];


            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i]==specialNumber)
                {
                    for (int j = 0; j < specialNumberPower; j++)
                    {
                        if (i<numbers.Count)
                        {
                            numbers.RemoveAt(i+1);
                        }
                    }
                    for (int j = 0; j < specialNumberPower; j++)
                    {
                        if (i>0)
                        {
                            numbers.RemoveAt(i - 1);
                            i--;
                        }
                    }
                }
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers.Remove(specialNumber);
            }
            var sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine(sum);
           

            
                    

        }
    }
}
