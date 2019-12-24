using System;
using System.Linq;

namespace _03._Space_Station_Establishment
{
    class Program
    {
        public static int stephenRow;
        public static int stephenCol;
        public static char[,] galaxy;
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            galaxy = new char[size, size];
            var collectedStarPower = 0;
            InitializeGalaxy();
            var isAlive = true;
            
            while (isAlive && collectedStarPower < 50)
            {
                var direction = Console.ReadLine();
                if (direction == "up")
                {
                    // row - 1 col
                    if (isInside(stephenRow - 1, stephenCol))
                    {
                        if (isThatCellBlackHole(stephenRow - 1, stephenCol))
                        {
                            galaxy[stephenRow, stephenCol] = '-';
                            galaxy[stephenRow - 1, stephenCol] = '-';
                            FindOtherBlackHole(stephenRow - 1, stephenCol);
                            galaxy[stephenRow, stephenCol] = 'S';
                        }
                        else if (char.IsDigit(galaxy[stephenRow - 1, stephenCol]))
                        {
                            collectedStarPower += int.Parse(galaxy[stephenRow - 1, stephenCol].ToString());
                            galaxy[stephenRow, stephenCol] = '-';
                            galaxy[stephenRow - 1, stephenCol] = 'S';
                            stephenRow--;
                        }
                        else
                        {
                            galaxy[stephenRow, stephenCol] = '-';
                            galaxy[stephenRow - 1, stephenCol] = 'S';
                            stephenRow--;
                        }

                    }
                    else
                    {
                        galaxy[stephenRow, stephenCol] = '-';
                        isAlive = false;
                    }
                }
                else if (direction == "right")
                {
                    //row col+1
                    if (isInside(stephenRow, stephenCol + 1))
                    {
                        if (isThatCellBlackHole(stephenRow, stephenCol + 1))
                        {
                            galaxy[stephenRow, stephenCol] = '-';
                            galaxy[stephenRow, stephenCol + 1] = '-';
                            FindOtherBlackHole(stephenRow, stephenCol + 1);
                            galaxy[stephenRow, stephenCol] = 'S';
                        }
                        else if (char.IsDigit(galaxy[stephenRow, stephenCol + 1]))
                        {
                            collectedStarPower += int.Parse(galaxy[stephenRow, stephenCol + 1].ToString());
                            galaxy[stephenRow, stephenCol] = '-';
                            galaxy[stephenRow, stephenCol + 1] = 'S';
                            stephenCol++;
                        }
                        else
                        {
                            galaxy[stephenRow, stephenCol] = '-';
                            galaxy[stephenRow, stephenCol + 1] = 'S';
                            stephenCol++;
                        }

                    }
                    else
                    {
                        galaxy[stephenRow, stephenCol] = '-';
                        isAlive = false;
                    }
                }
                else if (direction == "left")
                {
                    // row col-1
                    if (isInside(stephenRow, stephenCol - 1))
                    {
                        if (isThatCellBlackHole(stephenRow, stephenCol - 1))
                        {
                            galaxy[stephenRow, stephenCol] = '-';
                            galaxy[stephenRow, stephenCol - 1] = '-';
                            FindOtherBlackHole(stephenRow, stephenCol - 1);
                            galaxy[stephenRow, stephenCol] = 'S';
                        }
                        else if (char.IsDigit(galaxy[stephenRow, stephenCol - 1]))
                        {
                            collectedStarPower += int.Parse(galaxy[stephenRow, stephenCol - 1].ToString());
                            galaxy[stephenRow, stephenCol] = '-';
                            galaxy[stephenRow, stephenCol - 1] = 'S';
                            stephenCol--;
                        }
                        else
                        {
                            galaxy[stephenRow, stephenCol] = '-';
                            galaxy[stephenRow, stephenCol - 1] = 'S';
                            stephenCol--;
                        }

                    }
                    else
                    {
                        galaxy[stephenRow, stephenCol] = '-';
                        isAlive = false;
                    }
                }
                else if (direction == "down")
                {
                    //row + 1 col
                    if (isInside(stephenRow + 1, stephenCol))
                    {
                        if (isThatCellBlackHole(stephenRow + 1, stephenCol))
                        {
                            galaxy[stephenRow, stephenCol] = '-';
                            galaxy[stephenRow + 1, stephenCol] = '-';
                            FindOtherBlackHole(stephenRow + 1, stephenCol);
                            galaxy[stephenRow, stephenCol] = 'S';
                        }
                        else if (char.IsDigit(galaxy[stephenRow + 1, stephenCol]))
                        {
                            collectedStarPower += int.Parse(galaxy[stephenRow + 1, stephenCol].ToString());
                            galaxy[stephenRow, stephenCol] = '-';
                            galaxy[stephenRow + 1, stephenCol] = 'S';
                            stephenRow++;
                        }
                        else
                        {
                            galaxy[stephenRow, stephenCol] = '-';
                            galaxy[stephenRow + 1, stephenCol] = 'S';
                            stephenRow++;
                        }
                    }
                    else
                    {
                        galaxy[stephenRow, stephenCol] = '-';
                        isAlive = false;
                    }

                }
            }
            if (isAlive)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            }
            else
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }
            Console.WriteLine($"Star power collected: {collectedStarPower}");
            PrintGalaxy();
        }
            public static void PrintGalaxy()
            {
                for (int row = 0; row < galaxy.GetLength(0); row++)
                {
                    for (int col = 0; col < galaxy.GetLength(1); col++)
                    {
                        Console.Write(galaxy[row, col]);
                    }
                    Console.WriteLine();
                }
            }
            public static void InitializeGalaxy()
            {
                for (int row = 0; row < galaxy.GetLength(0); row++)
                {
                    var inputLines = Console.ReadLine()
                        .ToCharArray();
                    for (int col = 0; col < galaxy.GetLength(1); col++)
                    {
                        
                        galaxy[row, col] = inputLines[col];
                    if (isThatStephen(row, col))
                        {
                            stephenRow = row;
                            stephenCol = col;
                        }
                    }
                }
            }
            public static bool isThatStephen(int row, int col)
            {
                return galaxy[row, col] == 'S';
            }
            public static bool isInside(int row, int col)
            {
                return row >= 0 && row < galaxy.GetLength(0) &&
                    col >= 0 && col < galaxy.GetLength(1);
            }
            public static void FindOtherBlackHole(int currentRow, int currentCol)
            {
                for (int row = 0; row < galaxy.GetLength(0); row++)
                {
                    for (int col = 0; col < galaxy.GetLength(1); col++)
                    {
                        if (galaxy[row, col] == 'O' && currentCol != col && currentRow != row)
                        {
                            stephenRow = row;
                            stephenCol = col;
                            return;
                        }
                    }
                }
            }
            public static bool isThatCellBlackHole(int row, int col)
            {
                return galaxy[row, col] == 'O';
            }
        }
    }
