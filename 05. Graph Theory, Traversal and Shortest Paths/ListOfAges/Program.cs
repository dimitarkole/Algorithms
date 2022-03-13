using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfAges
{
    class Program
    {
        class Edge
        {
            public int Parent { get; set; }
            public int Child { get; set; }
        }


        static void Main(string[] args)
        {
            var graph = new List<Edge>() {
              new Edge() { Parent = 0, Child = 3 },
              new Edge() { Parent = 0, Child = 6 },
            };

            // Add an edge { 3 -> 6 }
            graph.Add(new Edge() { Parent = 3, Child = 6 });
            // List the children of node #1
            var childNodes = graph.Where(e => e.Parent == 1);
        }
    }
}
