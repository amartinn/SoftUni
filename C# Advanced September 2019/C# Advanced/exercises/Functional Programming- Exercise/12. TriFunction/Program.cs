using System;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Func<string, int, bool> isEqualOrLarger = (word, criteria) => word.Sum(x => x) >= criteria;
            var targetSum = int.Parse(Console.ReadLine());
            var inputNames = Console.ReadLine()
                .Split();
            Func<string[],Func<string,int,bool>,string> func = (names,isLarger) =>
                names.FirstOrDefault(x => isLarger(x, targetSum));
            var targetName = func(inputNames, isEqualOrLarger);
            Console.WriteLine(targetName);
        }
    }
}
