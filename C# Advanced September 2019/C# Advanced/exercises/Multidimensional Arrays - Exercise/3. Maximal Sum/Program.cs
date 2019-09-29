using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];
            var maxSum = int.MinValue;
            var maxStartingRow = 0;
            var maxStartingCol = 0;
            var matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputLine = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }
            for (int row = 0; row < matrix.GetLength(0)-2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    var currentSum = 0;
                    currentSum += matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                     matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row+1, col + 2] +
                     matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                  if (maxSum<currentSum)
                  {
                        maxStartingRow = row;
                        maxStartingCol = col;
                      maxSum = currentSum;
                  }
                }
             
            }
            Console.WriteLine($"Sum = {maxSum}");

            for (int row = maxStartingRow; row < maxStartingRow+3; row++)
            {
                for (int col = maxStartingCol; col < maxStartingCol+3; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
