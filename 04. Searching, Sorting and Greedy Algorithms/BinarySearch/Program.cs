using System;
using System.Collections.Generic;

namespace BinarySearch
{
    class Program
    {
        public static int startInx = 0;
        public static int endInd = 0;
        public static int midInd = 0;

        static void Main(string[] args)
        {
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            endInd = numbers.Count - 1;
            // numbers MUST BE SORT
            numbers.Sort();

            Console.WriteLine(Contains(numbers, 5));
        }

        private static int Contains(List<int> numbers, int searchNumber)
        {
            if (startInx > endInd)
            {
                return -1;
            }

            var midInd = (startInx + endInd) / 2;
            if (numbers[midInd] == searchNumber)
            {
                return midInd;
            }
            else if (searchNumber > numbers[midInd])
            {
                startInx = midInd + 1;
            }
            else
            {
                endInd = midInd - 1;
            }

            return Contains(numbers, searchNumber);
        }
    }
}
