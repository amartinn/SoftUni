using System;
using System.Linq;
namespace _04._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var symbols = Console.ReadLine()
                .Split()
                .ToArray();

            Array.Reverse(symbols);
            foreach (var symbol in symbols)
            {
                Console.Write(symbol+" ");
            }
        }
    }
}
