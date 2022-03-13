using System;
using System.Collections.Generic;

namespace Backtracking
{
    class Program
    {
        /*
         3
         3
         ---
         -*-
         --e
         * 
         * */
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            var lab = ReadData(rows, cols);
            FindAllPath(lab, 0, 0, new List<char>());
        }
        
        private static char[,] ReadData(int rows, int cols)
        {
            var lab = new char[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                var line = Console.ReadLine();
                for (int c = 0; c < line.Length; c++)
                {
                    lab[r, c] = line[c];
                }
            }

            return lab;
        }

        private static void FindAllPath(char[,] lab, int row, int col, List<char> derections, char derection = '\0')
        {
            if(IsOutside(lab, row, col) 
                || IsWall(lab, row, col)
                || IsVisited(lab, row, col))
            {
                return;
            }

            derections.Add(derection);

            if (IsSolution(lab, row, col))
            {
                Console.WriteLine(string.Join("", derections));
                derections.RemoveAt(derections.Count - 1);
                return;
            }

            lab[row, col] = 'v';

            FindAllPath(lab, row - 1, col,derections,'U');
            FindAllPath(lab, row  + 1, col, derections, 'D');
            FindAllPath(lab, row, col + 1, derections, 'R');
            FindAllPath(lab, row, col - 1, derections, 'L');

            derections.RemoveAt(derections.Count - 1);
            lab[row, col] = '-';
        }

        private static bool IsWall(char[,] lab, int row, int col)
            => lab[row, col] == '*';

        private static bool IsVisited(char[,] lab, int row, int col)
           => lab[row, col] == 'v';

        private static bool IsSolution(char[,] lab, int row, int col)
         => lab[row, col] == 'e';

        private static bool IsOutside(char[,] lab, int row, int col)
            => row < 0 ||
                row >= lab.GetLength(0) ||
                col < 0 ||
                col >= lab.GetLength(1);                
    }
}
