using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var primaryDiagonal = 0;
            var secondaryDiagonal = 0;
            var matrix = new int[size, size];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                    if (i == j)
                    {
                        primaryDiagonal += matrix[i, j];
                    }
                    if (i + j == size - 1)
                    {
                        secondaryDiagonal += matrix[i, j];
                    }
                }
            }
            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
