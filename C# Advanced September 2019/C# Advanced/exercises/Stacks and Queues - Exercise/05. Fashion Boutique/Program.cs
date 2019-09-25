using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            var capacity = int.Parse(Console.ReadLine());
            var currentRackCapacity = 0;
            var rackCounter = 1;
            while (clothes.Count>0)
            {
                currentRackCapacity += clothes.Peek();
                if (currentRackCapacity<=capacity)
                {
                    clothes.Pop();
                }
                else
                {
                    rackCounter++;
                    currentRackCapacity = 0;
                }
            }
            Console.WriteLine(rackCounter);
        }
    }
}
