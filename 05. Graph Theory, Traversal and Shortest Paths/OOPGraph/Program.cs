using System;

namespace OOPGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph<int>();

            // Add an edge { 3 -> 6 }
            graph.AddNode(1);
            graph.AddNode(2);
            graph.AddNode(3);
            graph.AddNode(4);

            graph.AddChildren(1, 2);
            graph.AddChildren(1, 3);
            graph.AddChildren(3, 1);
            graph.AddChildren(3, 4);

            // List the children of node #1
            var childNodes = graph.GetChildren(1);
        }
    }
}
