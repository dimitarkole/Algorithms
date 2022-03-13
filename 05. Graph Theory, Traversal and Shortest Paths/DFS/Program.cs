using System;
using System.Collections.Generic;

namespace DFS
{
    class Program
    {
        public static Dictionary<int, List<int>> graph;
        public static HashSet<int> visited;

        static void Main(string[] args)
        {
            graph = new Dictionary<int, List<int>>()
            {
                {1, new List<int>(){ 19, 21, 14 } },
                {19, new List<int>(){ 7, 19, 12, 31 } },
                {7, new List<int>(){ 1}},
                {12, new List<int>(){}},
                {6, new List<int>(){}},
                {21, new List<int>(){ 14 } },
                {31, new List<int>(){ 21 } },
                {14, new List<int>(){ 23, 6 } },
                {23, new List<int>(){ 21 } },
            };

            visited = new HashSet<int>();

            foreach (var node in graph.Keys)
            {
                DFS(node);
            }
        }

        public static void DFS(int node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            Console.WriteLine(node);
        }
    }
}
