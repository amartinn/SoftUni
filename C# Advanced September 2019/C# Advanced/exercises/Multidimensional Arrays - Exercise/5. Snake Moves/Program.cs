using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static char[,] matrix;
        static int counter = 0;
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            matrix = new char[rows, cols];

            var SnakeInputWord = Console.ReadLine();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row%2==0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        populateMatrix(row, col,SnakeInputWord);
                    }
                    
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        populateMatrix(row, col, SnakeInputWord);
                    }
                }

            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }


        }

        private static void populateMatrix(int row,int col, string word)
        {
            matrix[row, col] = word[counter++]; ;
            if (counter == word.Length)
            {
                counter = 0;
            }
        }
    }
}
