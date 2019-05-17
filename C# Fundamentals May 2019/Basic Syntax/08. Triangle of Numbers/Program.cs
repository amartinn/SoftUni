using System;

namespace _08._Triangle_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            for (int i = 1; i <=input; i++)
            {
                int count = i;
                for (int j = 0; j < count; j++)
                {
                    Console.Write(count+" ");
                }
                Console.WriteLine();
                count++;
            }
        }
    }
}
