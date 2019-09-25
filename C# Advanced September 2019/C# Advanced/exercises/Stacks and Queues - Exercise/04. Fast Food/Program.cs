    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace _04._Fast_Food
    {
        class Program
        {
            static void Main(string[] args)
            {
                var foodQuantity = int.Parse(Console.ReadLine());
                var orders = new Queue<int>(Console.ReadLine()
                    .Split()
                    .Select(int.Parse));
                Console.WriteLine(orders.Max());
                while (orders.Count>0)
                {
               
                    var currentOrder = orders.Peek();
                    if (foodQuantity-currentOrder>=0 && orders.Any())
                    {
                        foodQuantity -= currentOrder;
                        orders.Dequeue();
                    }
                    else
                    {
                        Console.Write("Orders left: ");
                        Console.Write(string.Join(" ",orders));
                        break;
                    }
                
                }
                if (!orders.Any())
                {
                    Console.WriteLine("Orders complete");
                }
            }
        }
    }
