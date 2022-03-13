using System;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 5, 6, 9, 1, 3, 9 };
            InertionSortFun(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void InertionSortFun(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                var j = i - 1;
                while(j > 0 && numbers[j- 1] > numbers[j])
                {
                    Swap(numbers, j, j - 1);
                    j--;
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
