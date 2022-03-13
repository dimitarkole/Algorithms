using System;

namespace PaskalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 2;
            int n = 4;

            Console.WriteLine(GetBinom(k, n));
        }

        private static int GetBinom(int row, int col)
        {
            if(row <=1 || col == 0 || col == row)
            {
                return 1;
            }

            return GetBinom(row - 1, col - 1) + GetBinom(row - 1, col + 1);
        }
    }
}
