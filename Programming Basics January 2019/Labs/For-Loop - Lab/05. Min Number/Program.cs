using System;
namespace _05.Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int minNum = int.MaxValue;
            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                if (currentNum < minNum)
                {
                    minNum = currentNum;
                }
            }
            Console.WriteLine(minNum);
        }
    }
}
