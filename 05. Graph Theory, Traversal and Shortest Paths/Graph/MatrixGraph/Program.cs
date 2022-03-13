using System;
using System.Collections.Generic;

namespace MatrixGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 4;
            var graph = new List<List<int>>()
            {
                new List<int>{ 1, 3}, // 0 -> 1, 3
                new List<int>{ 2 },   // 1 -> 1, 3
                new List<int>{ 0 },   // 2 -> 1, 3
                new List<int>{ 1 }    // 3 -> 1, 3
            };

            // add a age {3 -> 2}
            graph[3].Add(2);

            // get childrens
            var childrens = graph[1];
        }
    }
}
