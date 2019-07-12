using System;
using System.Linq;
namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var total = 0;
            var firstStr = input[0];
            var secondStr = input[1];
            var minLenght = Math.Min(firstStr.Length, secondStr.Length);
            for (int i = 0; i < minLenght; i++)
            {
                var firstElement = (int)firstStr[i];
                var secondElement = (int)secondStr[i];
                total += firstElement * secondElement;
            }
            var maxLenght = Math.Max(firstStr.Length, secondStr.Length);
            if (firstStr.Length > secondStr.Length)
            {
                for (int i = minLenght; i < maxLenght; i++)
                {
                    total += firstStr[i];
                }
            }
            else
            {
                for (int i = minLenght; i < maxLenght; i++)
                {
                    total += secondStr[i];
                }

            }
                Console.WriteLine(total);
        }
    }
}
