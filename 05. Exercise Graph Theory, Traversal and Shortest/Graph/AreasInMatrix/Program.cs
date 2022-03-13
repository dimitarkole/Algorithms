using System;
using System.Collections.Generic;

namespace AreasInMatrix
{
    class Program
    {
        class Node
        {

            public Node(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }

            public int Row{ get; set; }

            public int Col { get; set; }
        }

        private static char[,] matrix;
        private static bool[,] visited;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            matrix = ReadMatrix(n, m);
            visited = new bool[n, m];

            // area -> count
            var areas = new SortedDictionary<char, int>();
            var totalAreas = 0;
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < m; c++)
                {
                    if (visited[r, c])
                    {
                        continue;
                    }
                    totalAreas++;
                    DFS(r, c);
                    var key= matrix[r, c];
                    if (!areas.ContainsKey(key))
                    {
                        areas.Add(key, 1);
                    }
                    else
                    {
                        areas[key]++;
                    }
                }
            }

            Console.WriteLine("Areas: " + totalAreas);
            foreach (var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void DFS(int row, int col)
        {
            if (!visited[row, col])
            {
                return;
            }

            visited[row, col] = true;
            var children = GetChildren(row, col);

            foreach (var child in children)
            {
                DFS(child.Row, child.Col);
            }
        }

        private static List<Node> GetChildren(int row, int col)
        {
            var children = new List<Node>();
            if(IsInside(row-1, col) 
                && IsChild(row, col, row -1, col)
                && !IsVisitet(row - 1, col))
            {
                children.Add(new Node(row - 1, col));
            }

            if (IsInside(row + 1, col)
                && IsChild(row, col, row + 1, col)
                && !IsVisitet(row + 1, col))
            {
                children.Add(new Node(row + 1, col));
            }

            if (IsInside(row, col - 1)
                && IsChild(row, col, row, col - 1)
                && !IsVisitet(row, col - 1))
            {
                children.Add(new Node(row, col - 1));
            }

            if (IsInside(row, col + 1)
                && IsChild(row, col, row, col + 1)
                && !IsVisitet(row, col + 1))
            {
                children.Add(new Node(row, col + 1));
            }

            return children;
        }

        private static bool IsChild(int row, int col, int childRow, int childCol)
            => matrix[row, col] == matrix[childRow, childCol];

        private static bool IsVisitet(int row, int col)
          => visited[row, col];

        private static bool IsInside(int row, int col)
            => row >= 0 &&
                row < matrix.GetLength(0) &&
             col >= 0 &&
                col < matrix.GetLength(1);



        private static char[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var elements = Console.ReadLine();
                for (int col = 0; col < elements.Length; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            return matrix;
        }
    }
}
