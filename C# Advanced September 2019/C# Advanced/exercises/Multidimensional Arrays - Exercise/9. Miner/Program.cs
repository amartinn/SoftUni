using System;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        static char[,] mine;
        static int minerRow;
        static int minerCol;
        static int maximumCoal = 0;
        static int coalsCollected = 0;
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var commands = Console.ReadLine()
                .Split();

            mine = new char[size, size];
            InitializeMatrix();
            // •	* – a regular position on the field.
            //   •	e – the end of the route.
            //   •	c - coal
            //   •	s - the place where the miner starts
            var row = minerRow;
            var col = minerCol;
            for (int i = 0; i < commands.Length; i++)
            {
                var currentCommand = commands[i];
                
                        switch (currentCommand)
                        {
                            case "up":
                                // row - 1 col
                                if (IsInside(row  -1, col))
                                {
                                    if (IsThatCellCoal(row -1,col))
                                    {
                                        coalsCollected++;
                                    }
                                    else if (GameOver(row -1 ,col))
                                    {
                                printGameOver(row - 1, col);
                                    }
                                    mine[row, col] = '*';
                                    mine[row - 1, col] = 's';
                            row--;
                                }
                                break;
                            case "down":
                                //row + 1 col
                                if (IsInside(row + 1, col))
                                {
                                    if (IsThatCellCoal(row+1, col))
                                    {
                                        coalsCollected++;
                                    }
                                    else if (GameOver(row+1, col))
                                    {
                                printGameOver(row+1, col );
                                    }
                                    mine[row, col] = '*';
                                    mine[row + 1, col] = 's';
                            row++;
                                }
                                break;
                            case "left":
                                // row col-1
                                if (IsInside(row, col-1))
                                {
                                    if (IsThatCellCoal(row, col-1))
                                    {
                                        coalsCollected++;
                                    }
                                    else if (GameOver(row, col-1))
                                    {
                                printGameOver(row, col -1);
                                    }
                                    mine[row, col] = '*';
                                    mine[row , col -1] = 's';
                            col--;
                                }
                                break;
                            case "right":
                                //row col+1
                                if (IsInside(row, col+1))
                                {
                                    if (IsThatCellCoal(row, col+1))
                                    {
                                        coalsCollected++;
                                    }
                                    else if (GameOver(row, col+1))
                                    {
                                        printGameOver(row, col + 1);
                                    }
                                    mine[row, col] = '*';
                                    mine[row, col + 1] = 's';
                            col++;
                                }
                                break;

                        }
                if (coalsCollected == maximumCoal)
                {
                    Console.WriteLine($"You collected all coals! ({row}, {col})");
                    Environment.Exit(0);
                }
            }
            Console.WriteLine($"{maximumCoal-coalsCollected} coals left. ({row}, {col})");
        }
        private static void printGameOver(int row,int col)
        {
            Console.WriteLine($"Game over! ({row}, {col})");
            Environment.Exit(0);
        } 
    private static bool IsThatCellCoal(int row,int col)
        {
            return mine[row, col] == 'c';
        }
        private static bool GameOver(int row,int col)
        {
            return mine[row, col] == 'e';
        }
        private static void InitializeMatrix()
        {
            for (int row = 0; row < mine.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < mine.GetLength(1); col++)
                {
                    mine[row, col] = input[col];
                    if (isThatCellTheMiner(row,col))
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    if (mine[row,col]=='c')
                    {
                        maximumCoal++;
                    }
                }
            }
        }
        private static bool isThatCellTheMiner(int row,int col)
        {
            return mine[row, col] == 's';
        }
        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < mine.GetLength(0) &&
                col >= 0 && col < mine.GetLength(1);
        }
    }
}
