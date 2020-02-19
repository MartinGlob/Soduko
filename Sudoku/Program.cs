using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Sudoku
{
    class Program
    {
        static int[,] grid =
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

        static bool FindEmpty(out int r, out int c)
        {
            c = 0;
            for (r = 0; r < 9; r++)
                for (c = 0; c < 9; c++)
                    if (grid[r, c] == 0)
                        return true;
            return false;
        }

        static bool Possible(int row, int col, int v)
        {
            // check 3x3 square
            var sqRow =  (row / 3) * 3;
            var sqCol = (col / 3) * 3;

            for (var r = sqRow; r < sqRow + 3; r++)
                for (var c = sqCol; c < sqCol + 3; c++)
                    if (grid[r, c] == v)
                        return false;

            // check row
            for (var c = 0; c < 9; c++)
                if (grid[row, c] == v)
                    return false;

            // check col
            for (var r = 0; r < 9; r++)
                if (grid[r, col] == v)
                    return false;

            return true;
        }

        static bool Solve()
        {
            if (!FindEmpty(out var r, out var c))
                return true;

            for (var v = 1; v <= 9; v++)
            {
                if (Possible(r, c, v))
                {
                    grid[r, c] = v;
                    if (Solve())
                        return true;
                    grid[r, c] = 0;
                }
            }

            return false;
        }

        static void Main(string[] args)
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
                        Console.Write($"{grid[r, c]} ");
                    }

                    Console.WriteLine();
                }
            }
        }
        
    }



}
