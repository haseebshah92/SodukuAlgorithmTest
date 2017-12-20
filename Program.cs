
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudukuAlgorithmTest
{
    class SudokuPuzzleValidator
    {
        static void Main(string[] args)
        {
            int[][] goodSudoku1 = {
                new int[] {7,8,4,  1,5,9,  3,2,6},
                new int[] {5,3,9,  6,7,2,  8,4,1},
                new int[] {6,1,2,  4,3,8,  7,5,9},

                new int[] {9,2,8,  7,1,5,  4,6,3},
                new int[] {3,5,7,  8,4,6,  1,9,2},
                new int[] {4,6,1,  9,2,3,  5,8,7},

                new int[] {8,7,6,  3,9,4,  2,1,5},
                new int[] {2,4,3,  5,6,1,  9,7,8},
                new int[] {1,9,5,  2,8,7,  6,3,4}
            };


            int[][] goodSudoku2 = {
                new int[] {1,4, 2,3},
                new int[] {3,2, 4,1},

                new int[] {4,1, 3,2},
                new int[] {2,3, 1,4}
            };

            int[][] badSudoku1 =  {
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},

                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9},
                new int[] {1,2,3, 4,5,6, 7,8,9}
            };

            int[][] badSudoku2 = {
                new int[] {1,2,3,4,5},
                new int[] {1,2,3,4},
                new int[] {1,2,3,4},
                new int[] {1}
            };

            Console.WriteLine(ValidateSudoku(goodSudoku1).ToString() + ": This is supposed to validate! It's a good sudoku!");
            Console.WriteLine(ValidateSudoku(goodSudoku2).ToString() + ": This is supposed to validate! It's a good sudoku!");
            Console.WriteLine(ValidateSudoku(badSudoku1).ToString() + ": This isn't supposed to validate! It's a bad sudoku!");
            Console.WriteLine(ValidateSudoku(badSudoku2).ToString() + ": This isn't supposed to validate! It's a bad sudoku!");

            Console.ReadKey();
        }

        static bool ValidateSudoku(int[][] sodoku)
        {
            bool bSudoku = true;
            for (int i = 0; i < sodoku.Length; i++)
            {
                bSudoku = CheckSodoku(sodoku[i]);
                if (!bSudoku)
                    return false;
                var results = sodoku.Select(column => column.Skip(i).FirstOrDefault());
                bSudoku = CheckSodoku(results.ToArray());
                if (!bSudoku)
                    return false;
            };
            return true;
        }
        static bool CheckSodoku(int[] array)
        {
            int flag = 0;
            foreach (int value in array)
            {
                if (value != 0)
                {
                    int bit = 1 << value;
                    if ((flag & bit) != 0) return false;
                    flag |= bit;
                }
            }
            return true;          
        }
    }
}
