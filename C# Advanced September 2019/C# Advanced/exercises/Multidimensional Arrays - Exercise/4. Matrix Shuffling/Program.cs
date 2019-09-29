using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static string[,] matrix;
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];
            matrix = new string[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputLines = Console.ReadLine()
                    .Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLines[col];
                }
            }
            var commandArgs = string.Empty;
            while ((commandArgs=Console.ReadLine())!="END")
            {
                var splittedCommands = commandArgs
                    .Split();
                var command = splittedCommands[0];
               
                if (command=="swap" && splittedCommands.Length==5 )
                {
                    var firstRow = int.Parse(splittedCommands[1]);
                    var firstCol = int.Parse(splittedCommands[2]);
                    var secondRow = int.Parse(splittedCommands[3]);
                    var secondCol = int.Parse(splittedCommands[4]);
                    if (isInside(firstRow,firstCol) && isInside(secondRow,secondCol))
                    {
                        var firstCellToSwap = matrix[firstRow, firstCol];
                        var secondCellToSwap = matrix[secondRow, secondCol];
                        var temp = firstCellToSwap;
                        matrix[secondRow, secondCol] = temp;
                        matrix[firstRow, firstCol] = secondCellToSwap;
                        for (int row= 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row,col] + " ");
                            }
                            Console.WriteLine(  );
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

        }

        public static bool  isInside(int row,int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}
