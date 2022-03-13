using System;

namespace ArrayReccurtion
{
    public  class Program
    {
        static void Main(string[] args)
        {
            int[] masiv = new[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(CallcSumArr(masiv));
        }

        public static int CallcSumArr(int[] arr,  int index = 0)
        {
            if(index == arr.Length -1)
            {
                return arr[index];
            }

            return arr[index] + CallcSumArr(arr, index+1);
        }

        public static int CallcМultiplicationArr(int[] arr, int index = 0)
        {
            if (index == arr.Length - 1)
            {
                return arr[index];
            }

            return arr[index] * CallcSumArr(arr, index + 1);
        }


    }
}
