using System;
using System.Linq;
namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var evenPosition = new int[n];
            var oddPosition = new int[n];
            for (int i = 0; i < n; i++)
            {
                var inputs = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                if (i%2!=0)
                {
                    evenPosition[i] = inputs[1];
                    oddPosition[i] = inputs[0];
                }
                else
                {
                    evenPosition[i] = inputs[0];
                    oddPosition[i] = inputs[1];
                }
                
            }
            Console.WriteLine(string.Join(" ", evenPosition));
            Console.WriteLine(string.Join(" ", oddPosition));
        }
    }
}
