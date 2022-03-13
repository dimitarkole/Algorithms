using System;

namespace LinearSearching
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine(Contains(numbers, 5));
        }

        private static bool Contains(int[] numbers, int searchNumber)
        {
            foreach (var number in numbers)
            {
                if(number == searchNumber)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
