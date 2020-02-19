using System;

namespace Sudoku
{
    class Program
    {
        static readonly int[,] Grid =
        {
             { 8,0,0, 9,3,0,  0,0,2},
             { 0,0,9, 0,0,0,  0,4,0},
             { 7,0,2, 1,0,0,  9,6,0},

             { 2,0,0, 0,0,0,  0,9,0},
             { 0,6,0, 0,0,0,  0,7,0},
             { 0,7,0, 0,0,6,  0,0,5},

             { 0,2,7, 0,0,8,  4,0,6},
             { 0,3,0, 0,0,0,  5,0,0},
             { 5,0,0, 0,6,2,  0,0,8},

        };

        //private static int[,] grid =
        //{
        //    {7, 8, 0, 4, 0, 0, 1, 2, 0},
        //    {6, 0, 0, 0, 7, 5, 0, 0, 9},
        //    {0, 0, 0, 6, 0, 1, 0, 7, 8},
        //    {0, 0, 7, 0, 4, 0, 2, 6, 0},
        //    {0, 0, 1, 0, 5, 0, 9, 3, 0},
        //    {9, 0, 4, 0, 6, 0, 0, 0, 5},
        //    {0, 7, 0, 3, 0, 0, 0, 1, 2},
        //    {1, 2, 0, 0, 0, 7, 4, 0, 0},
        //    {0, 4, 9, 2, 0, 6, 0, 0, 7}
        //};

        private static bool Possible(int row, int col, int v)
        {
            // check 3x3 box
            var boxRow = (row / 3) * 3;
            var boxCol = (col / 3) * 3;

            for (var r = boxRow; r < boxRow + 3; r++)
                for (var c = boxCol; c < boxCol + 3; c++)
                    if (Grid[r, c] == v)
                        return false;

            // check row
            for (var c = 0; c < Grid.GetLength(0); c++)
                if (Grid[row, c] == v)
                    return false;

            // check col
            for (var r = 0; r < Grid.GetLength(0); r++)
                if (Grid[r, col] == v)
                    return false;

            return true;
        }

        private static bool Solve()
        {
            for (var r = 0; r < 9; r++)
                for (var c = 0; c < 9; c++)
                    if (Grid[r, c] == 0)
                    {
                        for (var v = 1; v <= 9; v++)
                        {
                            if (Possible(r, c, v))
                            {
                                Grid[r, c] = v;
                                if (Solve())
                                    return true;
                                Grid[r, c] = 0;
                            }
                        }
                        return false;
                    }

            return true;
        }

        private static void Main()
        {
            if (!Solve())
            {
                Console.WriteLine("No solution");
            }
            else
            {
                for (var r = 0; r < 9; r++)
                {
                    for (var c = 0; c < 9; c++)
                    {
                        Console.Write($"{Grid[r, c]} ");
                    }

                    Console.WriteLine();
                }
            }
        }

    }



}
