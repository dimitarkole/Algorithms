using System;

namespace BubbleSorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 5, 6, 9, 1, 3, 9 };
            BubbleSortFun(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void BubbleSortFun(int[] numbers)
        {
            var isSorted = false;
            var i = 0;
            while (!isSorted)
            {
                isSorted = true;
                for (int j = 1; j < numbers.Length - i; j++)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        Swap(numbers, j - 1, j);
                        isSorted = false;
                    }
                }
            }
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            var temp = numbers[first];
            numbers[first] = numbers[second];
            numbers[second] = temp;
        }
    }
}
