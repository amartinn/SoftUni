using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();
            var nPlusM = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var n = nPlusM[0];
            var m = nPlusM[1];
            var result = new List<int>();
            for (int i = 0; i < n; i++)
            {
                var inputNumber = int.Parse(Console.ReadLine());
                firstSet.Add(inputNumber);
            }
            for (int i = 0; i < m; i++)
            {
                var inputNumber = int.Parse(Console.ReadLine());
                    secondSet.Add(inputNumber);
                
            }
            var temp = firstSet.ToList();
            for (int i = 0; i < temp.Count; i++)
            {
                if (secondSet.Contains(temp[i]))
                {
                    result.Add(temp[i]);
                }
            }
            if (result.Any())
            {
                Console.WriteLine(string.Join(" ", result));
            }
            
            
        }
    }
}
