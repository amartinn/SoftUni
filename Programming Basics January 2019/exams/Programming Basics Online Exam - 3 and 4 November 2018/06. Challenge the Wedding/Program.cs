using System;
namespace _06.Challenge_the_Wedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int male = int.Parse(Console.ReadLine());
            int female = int.Parse(Console.ReadLine());
            int maxTables = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 1; i <= male; i++)
            {
                for (int j = 1; j <= female; j++)
                {
                    Console.Write($"({i} <-> {j})" + " ");
                    count++;
                    if (maxTables == count)
                    {
                        return;
                    }
                }
            }
        }
    }
}
