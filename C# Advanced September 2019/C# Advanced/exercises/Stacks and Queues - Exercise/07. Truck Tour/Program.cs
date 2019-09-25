using System;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var pumps = new int[n];
            for (int i = 0; i < n; i++)
            {
                var amountAndDistance = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                pumps[i] = amountAndDistance[0] - amountAndDistance[1];
            }
            int current = 0;
            int position = 0;
            for (int i = 0; i < n; i++)
            {
                current += pumps[i];
                if (current<0)
                {
                    current = 0;
                    position = i + 1;

                }
            }
            Console.WriteLine(position);
        }
    }
}
