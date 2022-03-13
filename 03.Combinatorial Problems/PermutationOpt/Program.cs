using System;
using System.Collections.Generic;

namespace PermutationOpt
{
    class Program
    {
        public static List<string> elements;
        public static List<string> permotations;

        static void Main(string[] args)
        {
            elements = new List<string>() { "A", "B", "C" };
            permotations = new List<string>();

            Permute(0);
        }

        private static void Permute(int permutationIndex)
        {
            if (permutationIndex >= elements.Count)
            {
                Console.WriteLine(string.Join("", permotations));
                return;
            }

            Permute(permutationIndex + 1);

            for (int elementIndex = permutationIndex+1; elementIndex < elements.Count; elementIndex++)
            {
                Slap(permutationIndex, elementIndex);
                Permute(elementIndex + 1);
                Slap(permutationIndex, elementIndex);
            }
        }

        private static void Slap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}
