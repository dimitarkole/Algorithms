using System;
using System.Collections.Generic;
using System.Linq;

namespace MoveDownRigthSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var numbers = ReadNumbers(rows, cols);

            var sums = new int[rows, cols];
            sums[0, 0] = numbers[0, 0];
            for (int c = 1; c < cols; c++)
            {
                sums[0, c] = sums[0, c - 1] + numbers[0, c];
            }

            for (int r = 1; r < rows; r++)
            {
                sums[r, 0] = sums[r - 1, 0] + numbers[r, 0];
            }

            for (int r = 1; r < rows; r++)
            {
                for (int c = 1; c < cols; c++)
                {
                    var upperCell = sums[r - 1, c];
                    var leftCell = sums[r, c - 1];
                    sums[r, c] = Math.Max(upperCell, leftCell) + numbers[r, c];
                }
            }

            var col = cols - 1;
            var row = rows -1;
            Console.WriteLine("Sum:" + sums[row, col]);
            var path = new Stack<string>();
            while (col > 0 && row > 0)
            {
                var upperCell = sums[row - 1, col];
                var leftCell = sums[row, col - 1];
                if (upperCell > leftCell)
                {
                    row--;
                }
                else
                {
                    col--;
                }

                path.Push($"[{row}, {col}]");
            }

            while (row > 0)
            {
                row--;
                path.Push($"[{row}, {col}]");
            }

            while (col > 0)
            {
                col--;
                path.Push($"[{row}, {col}]");
            }
            Console.WriteLine(string.Join(" ", path));
        }

        private static int[,] ReadNumbers(int rows, int cols)
        {
            var result = new int[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                var elemetns = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < cols; c++)
                {
                    result[r, c] = elemetns[c];
                }
            }

            return result;
        }
    }
}
