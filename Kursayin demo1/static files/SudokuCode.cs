using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursayin_demo1.static_files
{
    public class SudokuCode
    {
        static int n = 9; // number of columns/rows.
        static int srn = 3; // square root of N
        public static int numberOfRemovingPieces; // No. Of missing digits

        public static int[,] matrix = new int[n, n];
        public static int[,] answer = new int[n, n];
        // Sudoku Generator
        public static void fillValues()
        {
            matrix = new int[n, n];
            // Fill the diagonal of SRN x SRN matrices
            fillDiagonal();

            // Fill remaining blocks
            fillRemaining(0, srn);

            // Remove Randomly K digits to make game
            removeKDigits();
        }

        // Fill the diagonal SRN number of SRN x SRN matrices
        public static void fillDiagonal()
        {

            for (int i = 0; i < n; i = i + srn)
            {
                // for diagonal box, start coordinates->i==j
                fillBox(i, i);
            }
        }

        // Returns false if given 3 x 3 block contains num.
        static bool unUsedInBox(int rowStart, int colStart, int num)
        {
            for (int i = 0; i < srn; i++)
            {
                for (int j = 0; j < srn; j++)
                {
                    if (matrix[rowStart + i, colStart + j] == num)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // Fill a 3 x 3 matrix.
        public static void fillBox(int row, int col)
        {
            int num;
            for (int i = 0; i < srn; i++)
            {
                for (int j = 0; j < srn; j++)
                {
                    do
                    {
                        num = randomGenerator(n);
                    }
                    while (!unUsedInBox(row, col, num));

                    matrix[row + i, col + j] = num;
                }
            }
        }

        // Random generator
        static int randomGenerator(int num)
        {
            Random rand = new Random();
            return (int)Math.Floor((double)(rand.NextDouble() * num + 1));
        }

        // Check if safe to put in cell
        static bool CheckIfSafe(int i, int j, int num)
        {
            return (unUsedInRow(i, num) &&
                    unUsedInCol(j, num) &&
                    unUsedInBox(i - i % srn, j - j % srn, num));
        }

        // check in the row for existence
        static bool unUsedInRow(int i, int num)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == num)
                {
                    return false;
                }
            }
                
            return true;
        }

        // check in the row for existence
        static bool unUsedInCol(int j, int num)
        {
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, j] == num)
                {
                    return false;
                }
            }
                
            return true;
        }

        // A recursive function to fill remaining
        // matrix
        static bool fillRemaining(int i, int j)
        {
            //  System.out.println(i+" "+j);
            if (j >= n && i < n - 1)
            {
                i = i + 1;
                j = 0;
            }
            if (i >= n && j >= n)
                return true;

            if (i < srn)
            {
                if (j < srn)
                    j = srn;
            }
            else if (i < n - srn)
            {
                if (j == (int)(i / srn) * srn)
                    j = j + srn;
            }
            else
            {
                if (j == n - srn)
                {
                    i = i + 1;
                    j = 0;
                    if (i >= n)
                        return true;
                }
            }

            for (int num = 1; num <= n; num++)
            {
                if (CheckIfSafe(i, j, num))
                {
                    matrix[i, j] = num;
                    if (fillRemaining(i, j + 1))
                    {
                        return true;
                    }
                    matrix[i, j] = 0;
                }
            }
            return false;
        }

        // Remove the K no. of digits to
        // complete game
        static void removeKDigits()
        {
            RewriteValues();

            int count = numberOfRemovingPieces;
            while (count != 0)
            {
                int cellId = randomGenerator(n * n) - 1;

                // extract coordinates i  and j
                int i = (cellId / n);
                int j = cellId % 10;
                if (j != 0)
                {
                    j = j - 1;
                }

                if (matrix[i, j] != 0)
                {
                    count--;
                    matrix[i, j] = 0;
                }
            }
        }

        private static void RewriteValues()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int k = matrix[i, j];
                    answer[i, j] = k;
                }
            }
        }
    }
}
