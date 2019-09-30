using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static int[,] matrix;
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            matrix = new int[size, size];
            InitializeMatrix();
            var bombs = Console.ReadLine()
                .Split(new char[] { ' ', ',' })
                .Select(int.Parse)
                .ToArray();
            for (int i = 0; i < bombs.Length; i += 2)
            {
                var currentBombRow = bombs[i];
                var currentBombCol = bombs[i + 1];
                ReduceNumbersInMatrix(currentBombRow, currentBombCol);
               
            }
            PrintAliveCellsAndSum();
        }
    

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void PrintAliveCellsAndSum()
        {
            var temp = matrix
                .Cast<int>()
               .Where(x => x > 0)
                .ToList();
            var aliveCellsCount = temp.Count;
            var aliveCellsSum = temp.Sum();
            Console.WriteLine($"Alive cells: {aliveCellsCount}");
            Console.WriteLine($"Sum: {aliveCellsSum}");
            PrintMatrix();
        }

        private static bool hasItExploded(int row,int col)
        {
            return matrix[row, col] <= 0;
        }
        private static void ReduceNumbersInMatrix(int row,int col)
        {
            

                var bombValue = matrix[row, col];
                matrix[row, col] -= bombValue;
                //-1   -1
            if (IsInside(row - 1, col - 1) && !hasItExploded(row-1,col-1))
                {
                matrix[row - 1, col - 1] -= bombValue;
                }
                //-1   col
                if (IsInside(row - 1, col) && !hasItExploded(row - 1, col))
                { 
                matrix[row - 1, col] -= bombValue;
                }
                //-1    1
                if (IsInside(row - 1, col + 1) && !hasItExploded(row - 1, col + 1))
                {
                matrix[row - 1, col + 1] -= bombValue;
                }
                //row  1
                if (IsInside(row, col + 1) && !hasItExploded(row, col + 1))
                {
                matrix[row, col + 1] -= bombValue;
                }
                // 1    1
                if (IsInside(row + 1, col + 1) && !hasItExploded(row + 1, col + 1))
                {
                matrix[row + 1, col + 1] -= bombValue;
                }
                //1     col
                if (IsInside(row + 1, col) && !hasItExploded(row + 1, col))
                {
                matrix[row + 1, col] -= bombValue;
                }
                //1     -1
                if (IsInside(row + 1, col - 1) && !hasItExploded(row + 1, col-1))
                {
                matrix[row + 1, col - 1] -= bombValue;
                }
                //row    -1
                if (IsInside(row, col - 1) && !hasItExploded(row, col -1))
                {
                matrix[row, col - 1] -= bombValue;
                }
        }
        private static bool IsInside(int row,int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
        private static void InitializeMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
