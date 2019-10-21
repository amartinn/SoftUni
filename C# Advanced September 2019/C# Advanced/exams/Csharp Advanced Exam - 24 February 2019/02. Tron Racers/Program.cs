using System;

namespace _02._Tron_Racers
{
    class Program
    {
        static char[,] matrix;
        static int fRow;
        static int fCol;
        static int sRow;
        static int sCol;
        const char f = 'f';
        const char s = 's';
        static bool isAlive = true;
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            matrix = new char[size, size];
            InitializeMatrix();
            while (isAlive)
            {
                   var directions = Console.ReadLine()
                .Split();
                var fDirection = directions[0];
                var sDirection = directions[1];
                Moves(fDirection,'f');
                if (isAlive)
                {
                    Moves(sDirection,'s');
                }
               
            }
            PrintMatrix();

        }
        public static void Moves(string direction, char currentPlayer)
        {
            char enemyPlayer;
            int row = -1;
            int col = -1;
            if (currentPlayer==f)
            {
                enemyPlayer = s;
                row = fRow;
                col = fCol;
            }
            else
            {
                enemyPlayer = f;
                row = sRow;
                col = sCol;
            }
            if (direction == "up")
            {
                // row - 1 col
                if (IsInside(row - 1, col))
                {
                    if (matrix[row - 1, col] != enemyPlayer)
                    {
                        //moves
                        matrix[row - 1, col] = currentPlayer;
                        row--;
                    }
                    else if (matrix[row - 1, col] == enemyPlayer)
                    {
                        //dies
                        isAlive = false;
                        matrix[row - 1, col] = 'x';
                        row--;
                    }

                }
                else
                {
                    //goes out
                    row = matrix.GetLength(0) - 1;
                    matrix[row, col] = currentPlayer;
                }
            }
            else if (direction == "down")
            {
                //row + 1 col
                if (IsInside(row + 1, col))
                {
                    if (matrix[row + 1, col] != enemyPlayer)
                    {
                        //moves
                        matrix[row + 1, col] = currentPlayer;
                        row++;
                    }
                    else if (matrix[row + 1, col] == enemyPlayer)
                    {
                        //dies
                        isAlive = false;
                        matrix[row + 1, col] = 'x';
                        row++;
                    }

                }
                else
                {
                    //goes out
                    row = 0;
                    matrix[row, col] = currentPlayer;
                }
            }
            else if (direction == "left")
            {
                // row col-1
                if (IsInside(row, col - 1))
                {
                    if (matrix[row, col - 1] != enemyPlayer)
                    {
                        //moves
                        matrix[row, col - 1] = currentPlayer;
                        col--;
                    }
                    else if (matrix[row, col - 1] == enemyPlayer)
                    {
                        //dies
                        isAlive = false;
                        matrix[row, col - 1] = 'x';
                        col--;
                    }

                }
                else
                {
                    //goes out
                    col = matrix.GetLength(0) - 1;
                    matrix[row, col] = currentPlayer;
                }
            }
            else if (direction == "right")
            {
                //row col+1
                if (IsInside(row, col + 1))
                {
                    if (matrix[row, col + 1] != enemyPlayer)
                    {
                        //moves
                        matrix[row, col + 1] = currentPlayer;
                        col++;
                    }
                    else if (matrix[row, col + 1] == enemyPlayer)
                    {
                        //dies
                        isAlive = false;
                        matrix[row, col + 1] = 'x';
                        col++;
                    }

                }
                else
                {
                    //goes out
                    col = 0;
                    matrix[row, col] = currentPlayer;
                }
            }
            if (currentPlayer == f)
            {
                fRow = row;
                fCol = col;
            }
            else
            {
                sRow = row;
                sCol = col;
            }
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
                    if (IsThatFCharacter(row, col))
                    {
                        fRow = row;
                        fCol = col;

                    }
                    else if (IsThatSCharacter(row, col))
                    {
                        sRow = row;
                        sCol = col;
                    }
                }
            }
        }
        public static bool IsThatFCharacter(int row, int col) => matrix[row, col] == 'f';
        public static bool IsThatSCharacter(int row, int col) => matrix[row, col] == 's';
        public static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }
    }
}
