using System;
using System.Collections.Generic;
using System.Linq;

namespace SetCover
{
    class Program
    {
        static void Main(string[] args)
        {
            var universe = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            int n = 0;
            var sets = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                sets.Add(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            }
            // Read the input elements – universe and sets
            var selectedSets = new List<int[]>();
            while (universe.Count > 0)
            {
                var currentSet = sets
                  .OrderByDescending(s => s.Count(e => universe.Contains(e)))
                  .FirstOrDefault();
                foreach (var number in currentSet)
                { universe.Remove(number); }

                sets.Remove(currentSet);
                selectedSets.Add(currentSet);
            }
            // TODO: Pirnt the output
            foreach (var selectedSet in selectedSets)
            {
                Console.WriteLine(string.Join(", ", selectedSet));
            }
        }
    }
}
