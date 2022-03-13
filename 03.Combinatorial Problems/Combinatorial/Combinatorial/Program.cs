using System;

namespace Combinatorial
{
    class Program
    {
        public static string[] elements;
        private static int k;
        private static string[] combinations;

        static void Main(string[] args)
        {
            elements = new[] { "A", "B", "C" };
            k = 2;
            combinations = new string[k];    
            combinationsFun();
        }

        private static void combinationsFun(int combInx=0, int elmentStaetIndx = 0)
        {
            if (combInx == combinations.Length)
            {
                Console.WriteLine(string.Join("", combinations));
                return;
            }

            for (int i = elmentStaetIndx; i < elements.Length; i++)
            {
                combinations[combInx] = elements[i];
                combinationsFun(combInx + 1, i + 1);
            }
        }
    }
}
