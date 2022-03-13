using System;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new [] { 5, 6, 9, 1, 3, 9 };
            SelectionSortFun(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void SelectionSortFun(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var minInx = i;
                var minNumber = numbers[i];
                for (int j = i+1; j < numbers.Length; j++)
                {
                    if(numbers[j] < numbers[i])
                    {
                        minInx = j;
                        minNumber = numbers[j];
                    }
                }
                Swap(numbers, i, minInx);
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
