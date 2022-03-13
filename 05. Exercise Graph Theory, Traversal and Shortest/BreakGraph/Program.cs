using System;
using System.Collections.Generic;
using System.Linq;

namespace BreakGraph
{
    public class Edge 
    {
        public Edge(string first, string second)
        {
            First = first;
            Second = second;
        }

        public string First { get; set; }
        public string Second { get; set; }
    }

    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            ProcessInput(n);
            edges = edges
                .OrderBy(e => e.First)
                .ThenBy(e => e.Second)
                .ToList();

            var removeEdges = new List<Edge>();
            foreach (var edge in edges)
            {
                var first = edge.First;
                var second = edge.Second;

                graph[first].Remove(second);
                graph[second].Remove(first);
                if (HasPath(first, second))
                {
                    if(!removeEdges.Any(e => e.First == second && e.Second == first))
                    {
                        removeEdges.Add(edge);
                    }
                }
                else
                {
                    graph[first].Add(second);
                    graph[second].Add(first);
                }
            }

            Console.WriteLine($"Edges to remove {removeEdges.Count}");
            foreach (var edge in removeEdges)
            {
                Console.WriteLine($"{edge.First} -> {edge.Second}");
            }
        }

        private static bool HasPath(string source, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(source);

            var visited = new HashSet<string>() { source };
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if(node == destination)
                {
                    return true;
                }

                foreach (var child in graph[node])
                {
                    if(visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }

            return false;
        }

        private static void ProcessInput(int n)
        {
            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var parts = line.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                var node = parts[0];
                var children = parts[1].Split();

                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<string>());
                }

                foreach (var child in children)
                {
                    graph[node].Add(child);
                    edges.Add(new Edge(node, child));
                }
            }
        }
    }
}
