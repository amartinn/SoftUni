using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            //75/100
            var capacity = int.Parse(Console.ReadLine());
            var lettersAndNumbers = Console.ReadLine()
                .Split();
            var halls = new Queue<string>();
            var hallsAndReservations = new Dictionary<string, List<int>>();
         
            for (int i = lettersAndNumbers.Length - 1; i >= 0; i--)
            {
                var currentSymbol = lettersAndNumbers[i];
                if (int.TryParse(currentSymbol, out int number))
                {
                    var flag = false;
                    if (halls.Any())
                    {
                        var currentHall = halls.Peek();
                        var currentSum = hallsAndReservations[currentHall].Sum();
                        if (currentSum + number > capacity)
                        {
                          
                            Console.Write($"{currentHall} -> ");
                            Console.Write(string.Join(", ", hallsAndReservations[currentHall]));
                            Console.WriteLine();
                            halls.Dequeue();
                            hallsAndReservations.Remove(currentHall);
                            flag = true;
                        }
                        else
                        {
                            hallsAndReservations[currentHall].Add(number);
                        }
                        if (flag)
                        {
                            if (halls.Any())
                            {
                                currentHall = halls.Peek();
                                hallsAndReservations[currentHall].Add(number);
                            }
                           
                        }
                    }
                   
                   
                }
                else
                {
                    halls.Enqueue(currentSymbol);
                    hallsAndReservations[currentSymbol] = new List<int>();
                }
            }
        }
    }
}
