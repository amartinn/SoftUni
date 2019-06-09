using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
        }
        static void Init()
        {
            var number = int.Parse(Console.ReadLine());
            DrawMatrix(number);
        }
        static void DrawMatrix(int number)
        {
            for (int row = 0; row < number; row++)
            {
                for (int col = 0; col <number; col++)
                {
                    Console.Write(number+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
