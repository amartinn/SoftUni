using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<int, int>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());
                if (!dictionary.ContainsKey(currentNumber))
                {
                    dictionary[currentNumber] = 0;
                }
                dictionary[currentNumber]++;
            }
            var result = dictionary
                .FirstOrDefault(x => x.Value % 2 == 0);
            Console.WriteLine(result.Key);
        }
    }
}
