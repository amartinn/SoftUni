using System;
using System.Linq;

namespace _6._Jagged_Array
{
    class Program
    {
        static double[][] jaggedArray;
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            jaggedArray = new double[rows][];

            InitializeJaggedArray();
            Analyze();
            var commandArgs = string.Empty;
            while ((commandArgs = Console.ReadLine())!="End")
            {
                var splittedCommand = commandArgs.Split();
                var command = splittedCommand[0];
                var targetRow = int.Parse(splittedCommand[1]);
                var targetCol = int.Parse(splittedCommand[2]);
                var value = int.Parse(splittedCommand[3]);
                if (isInside(targetRow,targetCol))
                {
                    if (command=="Add")
                    {
                        jaggedArray[targetRow][targetCol] += value;
                    }
                    else
                    {
                        jaggedArray[targetRow][targetCol] -= value;
                    }
                }
            }
            printJaggedArray();
        }

        private static void printJaggedArray()
        {
            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
        private static bool isInside(int row,int col)
        {
            return row >= 0 && row < jaggedArray.Length &&
                col >= 0 && col < jaggedArray[row].Length;

        }
        private static void Analyze()
        {
            for (int row = 0; row < jaggedArray.GetLength(0)-1; row++)
            {
                var currentRowLenght = jaggedArray[row].Length;
                var belowCurrentRowLenght = jaggedArray[row + 1].Length;

                    if (currentRowLenght==belowCurrentRowLenght)
                    {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                    }
                    else
                    {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArray[row+1].Length; col++)
                    {
                        jaggedArray[row+1][col] /= 2;
                    }

                }
            }
        }

        private static void InitializeJaggedArray()
        {
            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                jaggedArray[row] = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();
            }
        }
    }
}
