using System;
using System.Collections.Generic;

namespace Variation
{
    class Program
    {
        public static List<string> elements;
        private static int k;
        private static string[] variation;
        private static bool[] used;

        static void Main(string[] args)
        {
            elements = new List<string>() { "A", "B", "C" };
            k = 2;
            variation = new string[k];
            used = new bool[elements.Count];
            VariationFun();
        }

        private static void VariationFun(int index = 0)
        {
            if(index >= variation.Length)
            {
                Console.WriteLine(string.Join("", variation));
            }

            for (int i = 0; i < elements.Count; i++)
            {
                if(!used[i])
                {
                    used[i] = true;
                    variation[index] = elements[i];
                    VariationFun(index + 1);
                    used[i] = true;

                }
            }
        }
    }
}
