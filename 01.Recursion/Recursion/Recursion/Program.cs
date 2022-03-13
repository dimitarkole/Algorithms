using System;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            CalcFact(5);
        }

        public static long CalcFact(int n)
        {
            if (n==1)
            {
                return n;
            }

            return n * CalcFact(n - 1);
        }

        public static void DrowFigure(int size)
        {
            if(size==0)
            {
                return;
            }

            Console.WriteLine(new string('*', size));
            DrowFigure(size - 1);
            Console.WriteLine(new string('#', size));
        }

        public static void Gen01(int[] vector, int index)
        {
            if (index == vector.Length -1)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int number = 0; number <= 1; number++)
            {
                vector[index] = number;
                Gen01(vector, index + 1);
            }
        }
    }
}
