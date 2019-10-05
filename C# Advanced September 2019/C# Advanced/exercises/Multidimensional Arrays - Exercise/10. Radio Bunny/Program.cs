using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radio_Bunny
{
    class Program
    {
        static char[,] matrix;
        static int playerRow;
        static int PlayerCol;
        static Dictionary<int, int> bunnyStop;
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];
            matrix = new char[rows, cols];
            bunnyStop = new Dictionary<int, int>();
            InitializeMatrix();
            var moves = Console.ReadLine();
            for (int i = 0; i < moves.Length; i++)
            {
                BunnySpread();
            }
            var movesCounter = 0;
        
         
         //   for (int i = 0; i < moves.Length; i++)
         //   {
         //
         //       var currentMove = moves[i]
         //       if (currentMove=='U')
         //       { // row - 1 col up
         //           if (IsInside(playerRow - 1, PlayerCol))
         //           {
         //
         //               if (isAlive(playerRow - 1, PlayerCol))
         //               {
         //                   PrintMatrix();
         //                   Console.WriteLine($"dead: {playerRow} {PlayerCol}");
         //                   Environment.Exit(0);
         //               }
         //               matrix[playerRow, PlayerCol] = '.';
         //               playerRow--;
         //               matrix[playerRow, PlayerCol] = 'P';
         //               BunnySpread();
         //               PrintMatrix();
         //               Console.WriteLine();
         //           }
         //       }
         //       else if (currentMove=='D')
         //       {
         //           // row + 1 col down
         //           if (IsInside(playerRow + 1, PlayerCol))
         //           {
         //
         //               if (isAlive(playerRow + 1, PlayerCol))
         //               {
         //                   PrintMatrix();
         //                   Console.WriteLine($"dead: {playerRow} {PlayerCol}");
         //                   Environment.Exit(0);
         //               }
         //               matrix[playerRow, PlayerCol] = '.';
         //               playerRow++;
         //               matrix[playerRow, PlayerCol] = 'P';
         //               BunnySpread();
         //               PrintMatrix();
         //               Console.WriteLine();
         //           }
         //       }
         //       else if (currentMove=='L')
         //       {
         //           // row col-1 left
         //           if (IsInside(playerRow, PlayerCol-1))
         //           {
         //
         //               if (isAlive(playerRow, PlayerCol-1))
         //               {
         //                   PrintMatrix();
         //                   Console.WriteLine($"dead: {playerRow} {PlayerCol-1}");
         //                   Console.WriteLine(movesCounter);
         //                   Environment.Exit(0);
         //               }
         //               matrix[playerRow, PlayerCol] = '.';
         //               PlayerCol--;
         //               matrix[playerRow, PlayerCol] = 'P';
         //               movesCounter++;
         //               BunnySpread();
         //               PrintMatrix();
         //               Console.WriteLine();
         //           }
         //       }
         //       else
         //       {
         //           // row col + 1 right 
         //       }
         //   }
            

        }
        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool isAlive(int row, int col)
        {
            return matrix[row, col] == 'B';
        }

        private static void BunnySpread()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var currentCell = matrix[row, col];
                    if (currentCell=='B')
                    {
                    //   row - 1 col up
                   
                        if (IsInside(row-1,col))
                        {
                     
                                matrix[row - 1, col] = 'B';
                        }
                        //   row + 1 col down
                        if (IsInside(row + 1, col))
                        {
                          
                            matrix[row + 1, col] = 'B';
                        
                        }
                        //   row col-1 left
                        if (IsInside(row , col -1 ))
                        {
                            matrix[row, col-1] = 'B';
                           

                        }

                        //   row col + 1 right
                        if (IsInside(row, col + 1))
                        {
                            matrix[row , col+1] = 'B';
                           
                        }
                        Console.WriteLine();
                        PrintMatrix();
                    }
                    
                }
            }
        }
        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
        private static void InitializeMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (input[col]=='P')
                    {
                        playerRow = row;
                        PlayerCol = col;
                    }
                    matrix[row, col] = input[col];
                }
            }
        }

    }
}
