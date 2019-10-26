using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var males = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));

            var females = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            var matchCounter = 0;
            while (males.Count>0 && females.Count>0)
            {
                var currentMale = males.Peek();
                var currentFemale = females.Peek();

                if (currentFemale <= 0 || currentMale <= 0)
                {
                    if (currentFemale<=0)
                    {
                        females.Dequeue();
                    }
                    else
                    {
                        males.Pop();
                    }
                    continue;
                   
                }
                if (currentFemale%25==0 || currentMale%25==0)
                {
                    if (currentFemale%25==0)
                    {
                        females.Dequeue();
                        females.Dequeue();
                    }
                   else
                    {
                        males.Pop();
                        males.Pop();
                    }
                    continue;
                }
             


                if (currentFemale== currentMale)
                {
                    matchCounter++;
                    males.Pop();
                    females.Dequeue();
                }
                else
                {
                    females.Dequeue();
                    males.Push(males.Pop() - 2);
                }
            }
            Console.WriteLine($"Matches: {matchCounter}");
            if (males.Any())
            {
                Console.WriteLine($"Males left: {string.Join(", ",males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }
            if (females.Any())
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
//3 0 3 6 9 0 12 -> male
//12 9 6 1 2 3 15 13 4 ->female
// 12 - 12 -> match
// 0  - 9 -> skip 
// 9  - 9