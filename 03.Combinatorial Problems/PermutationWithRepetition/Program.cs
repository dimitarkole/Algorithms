using System;
using System.Collections.Generic;

namespace PermutationWithRepetition
{
    class Program
    {
        public static List<string> elements;

        static void Main(string[] args)
        {
            elements = new List<string>() { "A", "B", "B" };

            Permute(0);
        }

        private static void Permute(int permutationIndex)
        {
            if (permutationIndex >= elements.Count)
            {
                Console.WriteLine(string.Join("", elements));
                return;
            }

            Permute(permutationIndex + 1);

            var swapped = new HashSet<string> { elements[permutationIndex] };
            for (int elementIndex = permutationIndex + 1; elementIndex < elements.Count; elementIndex++)
            {
                if(!swapped.Contains(elements[elementIndex]))
                {
                    Slap(permutationIndex, elementIndex);
                    Permute(elementIndex + 1);
                    Slap(permutationIndex, elementIndex);
                }
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
