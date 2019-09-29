using System;
using System.Linq;
namespace _2._squre_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = new char[rows, cols];
            var squireCounter = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    var currentStr = matrix[i, j];
                    if (currentStr == matrix[i, j + 1] &&
                        currentStr == matrix[i + 1, j] &&
                        currentStr == matrix[i + 1, j + 1])
                    {
                        squireCounter++;
                    }
                }

            }
            Console.WriteLine(squireCounter);
        }
    }
}
