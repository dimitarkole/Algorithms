using System;
using System.Collections.Generic;

namespace BFS
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
                BFS(node);
            }
        }

        public static void BFS(int startNode)
        {
            if (visited.Contains(startNode))
            {
                return;
            }

            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited.Add(startNode);

            while(queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.WriteLine(node);
                foreach (var child in graph[node])
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(child);
                        visited.Add(child);
                    }
                }
            }
        }
    }
}
