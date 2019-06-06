using System;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstArray = Console.ReadLine().Split();
            var secondArray = Console.ReadLine().Split();
            for (int i = 0; i < secondArray.Length; i++)
            {
                var number = secondArray[i];
                for (int j = 0; j < firstArray.Length; j++)
                {
                    var current = firstArray[j];
                    if (number==current) 
                    {
                        Console.Write(number+" ");
                    }
                }
            }
        }
    }
}
