using System;

namespace _7._Knight_Game
{
    class Program
    {
        static char[,] matrix;
        static int maxKnightAttackRow;
        static int maxKnightAttackCol;
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            matrix = new char[size, size];

           
            PopulateMatrix();
        }
        //
    
        private static void searchForKnights()
        {
            
            var removedKnightsCount = 0;
            bool isThereKnightToAttack = true;
            while (isThereKnightToAttack)
            {
                var maxAttacks = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        var knightAttackCounter = 0;
                        if (matrix[row, col] == 'K')
                        {

                            // -2 1
                            if (IsInside(row - 2, col + 1) && matrix[row - 2, col + 1] == 'K')
                            {
                                knightAttackCounter++;
                            }
                            //- 2 - 1
                            if (IsInside(row - 2, col - 1) && matrix[row - 2, col - 1] == 'K')
                            {
                                knightAttackCounter++;
                            }
                            //- 1 2
                            if (IsInside(row - 1, col + 2) && matrix[row - 1, col + 2] == 'K')
                            {
                                knightAttackCounter++;
                            }
                            // - 1 - 2
                            if (IsInside(row - 1, col - 2) && matrix[row - 1, col - 2] == 'K')
                            {
                                knightAttackCounter++;
                            }
                            //1 2
                            if (IsInside(row + 1, col + 2) && matrix[row + 1, col + 2] == 'K')
                            {
                                knightAttackCounter++;
                            }
                            //1 - 2
                            if (IsInside(row + 1, col - 2) && matrix[row + 1, col - 2] == 'K')
                            {
                                knightAttackCounter++;
                            }
                            //2 1
                            if (IsInside(row + 2, col + 1) && matrix[row + 2, col + 1] == 'K')
                            {
                                knightAttackCounter++;
                            }
                            //2 - 1
                            if (IsInside(row + 2, col - 1) && matrix[row + 2, col - 1] == 'K')
                            {
                                knightAttackCounter++;
                            }

                        }
                        if (knightAttackCounter > maxAttacks)
                        {
                            maxAttacks = knightAttackCounter;
                            maxKnightAttackRow = row;
                            maxKnightAttackCol = col;
                        }
                    }
                   
                }
                if (maxAttacks > 0)
                {
                    matrix[maxKnightAttackRow, maxKnightAttackCol] = '0';
                    removedKnightsCount++;
                }
                else
                {
                    Print(removedKnightsCount);
                    isThereKnightToAttack = false;
                }
            }
            

        }

        private static void Print(int removedKnightsCount) => Console.WriteLine(removedKnightsCount);

        private static void PopulateMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            searchForKnights();
        }
        public static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}
