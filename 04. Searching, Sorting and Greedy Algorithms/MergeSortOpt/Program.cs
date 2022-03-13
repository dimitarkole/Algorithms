using System;

namespace MergeSortOpt
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 5, 6, 9, 1, 3, 9 };
            var sortedNumbers = MergeSort(numbers);
            Console.WriteLine(string.Join(" ", sortedNumbers));
        }

        // Memory: O(n)
        public static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
                return array;

            var copy = new int[array.Length];
            Array.Copy(array, copy, array.Length);

            MergeSortHelper(array, copy, 0, array.Length - 1);

            return array;
        }

        public static void MergeSortHelper(int[] source, int[] copy, int leftIdx, int rightIdx)
        {
            if (leftIdx >= rightIdx)
                return;

            var middleIdx = (leftIdx + rightIdx) / 2;
            MergeSortHelper(copy, source, leftIdx, middleIdx);
            MergeSortHelper(copy, source, middleIdx + 1, rightIdx);

            MergeArrays(source, copy, leftIdx, middleIdx, rightIdx);
        }

        public static void MergeArrays(int[] source, int[] copy, int startIdx, int middleIdx, int endIdx)
        {
            var sourceIdx = startIdx;
            var leftIdx = startIdx; var rightIdx = middleIdx + 1;
            while (leftIdx <= middleIdx && rightIdx <= endIdx)
            {
                if (copy[leftIdx] < copy[rightIdx])
                    source[sourceIdx++] = copy[leftIdx++];
                else
                    source[sourceIdx++] = copy[rightIdx++];
            }


            while (leftIdx <= middleIdx)
            {
                source[sourceIdx] = copy[leftIdx];
                leftIdx += 1;
                sourceIdx += 1;
            }

            while (rightIdx <= endIdx)
            {
                source[sourceIdx] = copy[rightIdx];
                rightIdx += 1;
                sourceIdx += 1;
            }
        }
    }
}
