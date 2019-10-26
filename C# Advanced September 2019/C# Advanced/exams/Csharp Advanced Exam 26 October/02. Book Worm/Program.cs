using System;
using System.Linq;

namespace _02._Book_Worm
{
    class Program
    {
        static char[,] matrix;
        static int PRow;
        static int PCol;
        static void Main(string[] args)
        {
            var word = Console.ReadLine()
                .ToCharArray()
                .ToList();
            var size = int.Parse(Console.ReadLine());
            matrix = new char[size, size];
            InitializeMatrix();
            var command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "up")
                {
                    // row - 1 col
                    if (IsInside(PRow - 1, PCol))
                    {
                        if (char.IsLetter(matrix[PRow - 1, PCol]))
                        {
                            var letter = matrix[PRow - 1, PCol];
                            word.Add(letter);
                            matrix[PRow, PCol] = '-';
                            PRow--;
                            matrix[PRow, PCol] = 'P';

                        }
                        else
                        {
                            matrix[PRow, PCol] = '-';
                            PRow--;
                            matrix[PRow, PCol] = 'P';
                        }
                    }
                    else
                    {
                        if (word.Any())
                        {
                            word.RemoveAt(word.Count - 1);
                        }
                    }
                }
                else if (command == "down")
                {
                    //row + 1 col
                    if (IsInside(PRow + 1, PCol))
                    {
                        if (char.IsLetter(matrix[PRow + 1, PCol]))
                        {
                            var letter = matrix[PRow + 1, PCol];
                            word.Add(letter);
                            matrix[PRow, PCol] = '-';
                            PRow++;
                            matrix[PRow, PCol] = 'P';

                        }
                        else
                        {
                            matrix[PRow, PCol] = '-';
                            PRow++;
                            matrix[PRow, PCol] = 'P';
                        }
                    }
                    else
                    {
                        if (word.Any())
                        {
                            word.RemoveAt(word.Count - 1);
                        }
                    }
                }
                else if (command == "left")
                {
                    // row col-1
                    if (IsInside(PRow, PCol - 1))
                    {
                        if (char.IsLetter(matrix[PRow, PCol - 1]))
                        {
                            var letter = matrix[PRow, PCol - 1];
                            word.Add(letter);
                            matrix[PRow, PCol] = '-';
                            PCol--;
                            matrix[PRow, PCol] = 'P';

                        }
                        else
                        {
                            matrix[PRow, PCol] = '-';
                            PCol--;
                            matrix[PRow, PCol] = 'P';
                        }
                    }
                    else
                    {
                        if (word.Any())
                        {
                            word.RemoveAt(word.Count - 1);
                        }
                    }
                }
                else if (command == "right")
                {
                    // row col+1
                    if (IsInside(PRow, PCol + 1))
                    {
                        if (char.IsLetter(matrix[PRow, PCol + 1]))
                        {
                            var letter = matrix[PRow, PCol + 1];
                            word.Add(letter);
                            matrix[PRow, PCol] = '-';
                            PCol++;
                            matrix[PRow, PCol] = 'P';

                        }
                        else
                        {
                            matrix[PRow, PCol] = '-';
                            PCol++;
                            matrix[PRow, PCol] = 'P';
                        }
                    }
                    else
                    {
                        if (word.Any())
                        {
                            word.RemoveAt(word.Count - 1);
                        }
                    }

                }
            }
            Console.WriteLine(string.Join("", word));
            PrintMatrix();
        }
        public static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        public static void InitializeMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputLines = Console.ReadLine()
                    .ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    matrix[row, col] = inputLines[col];
                    if (isThatPCharacter(row,col))
                    {
                        PRow = row;
                        PCol = col;
                    }

                }
            }
        }
        public static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
        public static bool isThatPCharacter(int row, int col) => matrix[row, col] == 'P';
    }
}
