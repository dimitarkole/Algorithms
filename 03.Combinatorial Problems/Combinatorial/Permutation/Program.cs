using System;
using System.Collections.Generic;
using System.Linq;

namespace Permutation
{
    class Program
    {
        public static List<string> elements;
        public static string[] permotations;

        static void Main(string[] args)
        {
            elements = new List<string>() { "A", "B", "C" };
            permotations = new string[elements.Count];
            Permute(0);
        }

        private static void Permute(int permutationIndex)
        {
            if(permutationIndex >= elements.Count)
            {
                Console.WriteLine(string.Join("", permotations));
                return;
            }

            for (int elementIndex = 0; elementIndex < elements.Count; elementIndex++)
            {
                var element = elements[elementIndex];
                if (!(permotations.Contains(element)))
                {
                    permotations[permutationIndex] = elements[elementIndex];
                    Permute(permutationIndex + 1);
                    permotations[permutationIndex] = "";
                }
            }
        }
    }
}
