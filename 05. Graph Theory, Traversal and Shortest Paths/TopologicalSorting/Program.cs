using System;
using System.Collections.Generic;
using System.Linq;

namespace TopologicalSorting
{
    class Program
    {
        public static Dictionary<int, List<int>> graph;
        public static Dictionary<int, int> depedencies;
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

            depedencies = ExtractDepedencies();

            var sorted = TopologicalSorting();

            if(sorted == null)
            {
                Console.WriteLine("Invalide topological sorting");
            }
            else
            {
                Console.WriteLine(string.Join(" ", sorted));
            }
        }

        private static List<int> TopologicalSorting()
        {
            var sortedResults = new List<int>();
            while (depedencies.Count > 0)
            {
                var noteToRemove = depedencies
                    .Where(n => n.Value == 0)
                    .FirstOrDefault();

                if(noteToRemove.Key == 0)
                {
                    break;
                }

                var node = noteToRemove.Key;
                var children = graph[node];

                foreach (var child in children)
                {
                    depedencies[child]--;
                }

                sortedResults.Add(node);
                depedencies.Remove(node);
            }

            if(depedencies.Count > 0)
            {
                return null;
            }

            return sortedResults;
        }

        private static Dictionary<int, int> ExtractDepedencies()
        {
            var results = new Dictionary<int, int>();

            foreach (var kpd in graph)
            {
                var node = kpd.Key;
                var children = kpd.Value;
                if (!results.ContainsKey(node))
                {
                    results.Add(node, 0);
                }

                foreach (var child in children)
                {
                    if(!results.ContainsKey(child))
                    {
                        results.Add(child, 1);
                    }
                    else
                    {
                        results[child] += 1;
                    }

                }
            }

            return results;
        }
    }
}
